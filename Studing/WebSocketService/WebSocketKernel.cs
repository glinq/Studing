using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketServices;

namespace WebSocketService
{
    public class WebSocketKernel
    {
        private IApplicationBuilder _app;

        private WebSocketServerMg _server;

        public WebSocketKernel(IApplicationBuilder app)
        {
            _server = new WebSocketServerMg();
            _app = app;
            _app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();

                    var client = new WebSocketClient()
                    {
                        ClientIp = context.Connection.RemoteIpAddress.ToString(),
                        ClientPort = context.Connection.RemotePort,
                        ServerIp = context.Connection.LocalIpAddress.ToString(),
                        ServerPort = context.Connection.LocalPort,
                        SessionId = context.Session.Id,
                        WebSocket = webSocket,
                        Context = context
                    };
                    //订阅事件
                    client.OnReceive += _OnReceive;
                    client.OnConnect += _OnConnect;
                    client.OnClose += _OnClose;
                    await _server.AddClient(client);
                }
                else
                {
                    await next();
                }
            });

        }

        /// <summary>
        /// 收到消息
        /// </summary>
        public event EventHandler<DataEventArgs<string, WebSocketClient>> OnClientReceive;

        private void _OnReceive(object sender, DataEventArgs<string, WebSocketClient> e)
        {
            OnClientReceive?.Invoke(this, e);
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public event EventHandler<DataEventArgs<string, WebSocketClient>> OnClientClose;
        private void _OnClose(object sender, DataEventArgs<string, WebSocketClient> e)
        {
            OnClientClose?.Invoke(this, e);
            WebSocketClientMg.Instance.Remove(e.Arg1);
        }
        /// <summary>
        /// 连接
        /// </summary>
        public event EventHandler<DataEventArgs<string, WebSocketClient>> OnClientConnect;

        private void _OnConnect(object sender, DataEventArgs<string, WebSocketClient> e)
        {
            OnClientConnect?.Invoke(this, e);
        }
        /// <summary>
        /// 获取所有客户端
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, WebSocketClient> GetAllClient()
        {
            return _server.GetAllClient();
        }
        /// <summary>
        /// 单发客户端
        /// </summary>
        /// <param name="sessionid">sessionid</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public async Task SendTo(string sessionid, string msg)
        {
            await _server.SendTo(sessionid, msg);
        }

        /// <summary>
        /// 群发
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public async Task SendAll(string msg)
        {
            await _server.SendAll(msg);
        }
    }
}
