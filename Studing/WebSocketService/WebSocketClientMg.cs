using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketServices
{
    public class WebSocketClientMg
    {
        private static readonly object o = new object();
        private static WebSocketClientMg _instance = null;
        public static WebSocketClientMg Instance
        {
            get
            {
                lock (o)
                {
                    if (_instance == null)
                    {
                        _instance = new WebSocketClientMg();
                    }
                    return _instance;
                }
            }
        }

        private Dictionary<string, WebSocketClient> _sessionclients;

        public WebSocketClientMg()
        {
            _sessionclients = new Dictionary<string, WebSocketClient>();
        }

        public Dictionary<string, WebSocketClient> GetClients()
        {
            return _sessionclients;
        }

        public WebSocketClient GetClientBySessionId(string sessionid)
        {
            return _sessionclients[sessionid];
        }

        public void AddClient(WebSocketClient client)
        {
            _sessionclients.Add(client.SessionId, client);
        }

        public async Task SendAll(string msg)
        {
            foreach (var client in _sessionclients.Values)
            {
                await client.SendMsg(msg);
            }
        }

        public async Task SendTo(string sessionid, string msg)
        {
            var client = _sessionclients[sessionid];
            await client.SendMsg(msg);

        }

        public void Remove(string eArg1)
        {
            var client = _sessionclients[eArg1];
            _sessionclients.Remove(eArg1);

        }

        public async void Close(string sessionId)
        {
            var client = _sessionclients[sessionId];
            _sessionclients.Remove(sessionId);
            await client.Close();
        }
    }

    public class WebSocketClient
    {
        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIp { get; set; }

        /// <summary>
        /// 客户端端口
        /// </summary>
        public int ClientPort { get; set; }

        /// <summary>
        /// 服务端IP
        /// </summary>
        public string ServerIp { get; set; }

        /// <summary>
        /// 服务端IP
        /// </summary>
        public int ServerPort { get; set; }

        /// <summary>
        /// SessionId
        /// </summary>
        public string SessionId { get; set; }

        public WebSocket WebSocket { get; set; }

        public HttpContext Context { get; set; }


        public event EventHandler<DataEventArgs<string, WebSocketClient>> OnReceive;

        public event EventHandler<DataEventArgs<string, WebSocketClient>> OnClose;

        public event EventHandler<DataEventArgs<string, WebSocketClient>> OnConnect;

        public async Task SendMsg(string msg)
        {
            var buffer = Encoding.UTF8.GetBytes(msg);
            await WebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task StartReceive()
        {
            var pgsize = 4;
            var buffer = new byte[1024 * pgsize];
            OnOnConnect(new DataEventArgs<string, WebSocketClient>(SessionId, this));
            var result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var msg = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    OnOnReceive(new DataEventArgs<string, WebSocketClient>(msg, this));
                }
                result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await WebSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            OnOnClose(new DataEventArgs<string, WebSocketClient>(SessionId, this));
        }


        protected virtual void OnOnReceive(DataEventArgs<string, WebSocketClient> e)
        {
            OnReceive?.Invoke(this, e);
        }

        protected virtual void OnOnClose(DataEventArgs<string, WebSocketClient> e)
        {
            WebSocket.Dispose();
            OnClose?.Invoke(this, e);
        }

        protected virtual void OnOnConnect(DataEventArgs<string, WebSocketClient> e)
        {
            OnConnect?.Invoke(this, e);
        }

        public async Task Close()
        {
            await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, WebSocket.CloseStatusDescription, CancellationToken.None);
            OnOnClose(new DataEventArgs<string, WebSocketClient>(SessionId, this));
        }
    }
}
