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

        private Dictionary<string, WebSocket> ConnectPool = new Dictionary<string, WebSocket>();

        private Dictionary<string, List<MessageInfo>> MessagePool = new Dictionary<string, List<MessageInfo>>();

        public MyWebSocketService(IApplicationBuilder app)
        {
            _app = app;
            _app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket WebSocket = await context.WebSockets.AcceptWebSocketAsync();
                    string keys = context.Request.Query["user"].ToString().Trim();
                    if (!ConnectPool.ContainsKey(keys))
                    {
                        ConnectPool.Add(keys, WebSocket);
                    }
                    if (ConnectPool[keys] != WebSocket)
                    {
                        ConnectPool[keys] = WebSocket;
                    }
                    if (MessagePool.ContainsKey(keys))
                    {
                        List<MessageInfo> messagelist = MessagePool[keys];
                        messagelist.ForEach(async f => { await WebSocket.SendAsync(f.MsgContent, WebSocketMessageType.Text, true, CancellationToken.None); });
                        MessagePool.Remove(keys);
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
                            string[] strarr = message.Split('|');
                            string receiverKey = string.Empty;
                            if (strarr.Length == 2)
                            {
                                receiverKey = strarr[0];
                                buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"{receiverKey}   {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}<br/>{strarr[1]}"));
                            }
                            if (WebSocket.CloseStatus.HasValue)
                            {
                                if (ConnectPool.ContainsKey(keys))
                                {
                                    ConnectPool.Remove(keys);
                                    WebSocket.Dispose();
                                }
                                break;
                            }
                            if (ConnectPool.ContainsKey(receiverKey))
                            {
                                WebSocket receiversocket = ConnectPool[receiverKey];
                                if (receiversocket != null && receiversocket.State == WebSocketState.Open)
                                {
                                    await receiversocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                                }
                            }
                            else
                            {
                                if (!MessagePool.ContainsKey(receiverKey))
                                {
                                    MessagePool.Add(receiverKey, new List<MessageInfo>());
                                }
                                MessagePool[receiverKey].Add(new MessageInfo(DateTime.Now, buffer));
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
        public MessageInfo(DateTime _MsgTime, ArraySegment<byte> _MsgContent)
        {
            MsgTime = _MsgTime;
            MsgContent = _MsgContent;
        }
        public DateTime MsgTime { get; set; }
        public ArraySegment<byte> MsgContent { get; set; }
    }
}

