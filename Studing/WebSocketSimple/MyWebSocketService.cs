using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketSimpleService
{
    public class MyWebSocketService
    {
        private IApplicationBuilder _app;
        /// <summary>
        /// 连接池 from ,(to,websocket) 
        /// </summary>
        public static Dictionary<string, Tuple<string, WebSocket>> ConnectPool = new Dictionary<string, Tuple<string, WebSocket>>();
        /// <summary>
        /// 离线消息池 to ,(from,websocket) 
        /// </summary>
        public static Dictionary<string, List<MessageInfo>> MessagePool = new Dictionary<string, List<MessageInfo>>();

        public MyWebSocketService(IApplicationBuilder app)
        {
            _app = app;
            _app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket WebSocket = await context.WebSockets.AcceptWebSocketAsync();
                    string from = context.Request.Query["from"].ToString().Trim();
                    string to = context.Request.Query["to"].ToString().Trim();
                    if (!ConnectPool.ContainsKey(from))
                    {
                        ConnectPool.Add(from, new Tuple<string, WebSocket>(to, WebSocket));
                    }
                    if (ConnectPool[from].Item1 != to || ConnectPool[from].Item2 != WebSocket)
                    {
                        ConnectPool[from] = new Tuple<string, WebSocket>(to, WebSocket);
                    }
                    if (MessagePool.ContainsKey(from))
                    {
                        List<MessageInfo> messagelist = MessagePool[from];
                        messagelist.ForEach(async f => { await WebSocket.SendAsync(f.MsgContent, WebSocketMessageType.Text, true, CancellationToken.None); });
                        MessagePool.Remove(from);
                    }
                    while (true)
                    {
                        if (WebSocket.State != WebSocketState.Open)
                        {
                            break;
                        }

                        try
                        {
                            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                            WebSocketReceiveResult receiveinfo = await WebSocket.ReceiveAsync(buffer, CancellationToken.None);
                            string message = Encoding.UTF8.GetString(buffer.Array, 0, receiveinfo.Count);
                            string[] strarr = message.Split('ф');
                            string touser = string.Empty;
                            string fromuser = string.Empty;
                            if (strarr.Length == 3)
                            {
                                fromuser = strarr[0];
                                touser = strarr[1];
                                buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"{fromuser} {DateTime.Now.ToString("HH:mm:ss")}<br/>{strarr[2]}"));
                            }
                            if (WebSocket.CloseStatus.HasValue)
                            {
                                if (ConnectPool.ContainsKey(from))
                                {
                                    ConnectPool.Remove(from);
                                    WebSocket.Dispose();
                                }
                                break;
                            }
                            if (ConnectPool.ContainsKey(touser))
                            {
                                WebSocket receiversocket = ConnectPool[touser].Item2;
                                if (receiversocket != null && receiversocket.State == WebSocketState.Open)
                                {
                                    await receiversocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                                }
                            }
                            else
                            {
                                if (!MessagePool.ContainsKey(touser))
                                {
                                    MessagePool.Add(touser, new List<MessageInfo>());
                                }
                                MessagePool[touser].Add(new MessageInfo(DateTime.Now, buffer, fromuser = from));
                            }
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                }
                else
                {
                    await next();
                }
            });
        }
    }

    public class MessageInfo
    {
        public MessageInfo(DateTime _MsgTime, ArraySegment<byte> _MsgContent, string fromuser)
        {
            MsgTime = _MsgTime;
            MsgContent = _MsgContent;
            FromUser = fromuser;
        }
        public DateTime MsgTime { get; set; }
        public ArraySegment<byte> MsgContent { get; set; }

        public string FromUser { get; set; }
    }
}

