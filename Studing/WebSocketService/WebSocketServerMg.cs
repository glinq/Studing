using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServices
{
    public class WebSocketServerMg
    {
        //构造函数
        public WebSocketServerMg()
        {

        }

        /// <summary>
        /// 新增客户端
        /// </summary>
        /// <param name="client">客户端请求</param>
        /// <returns></returns>
        public async Task AddClient(WebSocketClient client)
        {
            WebSocketClientMg.Instance.AddClient(client);
            await client.StartReceive();
        }

        /// <summary>
        /// 全发
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public async Task SendAll(string msg)
        {
            await WebSocketClientMg.Instance.SendAll(msg);
        }

        /// <summary>
        /// 发送给对应客户端
        /// </summary>
        /// <param name="sessionid">sessionid</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public async Task SendTo(string sessionid, string msg)
        {
            await WebSocketClientMg.Instance.SendTo(sessionid, msg);

        }

        /// <summary>
        /// 获取所有客户端
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, WebSocketClient> GetAllClient()
        {
            return WebSocketClientMg.Instance.GetClients();
        }

        /// <summary>
        /// 获取单个客户端
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public WebSocketClient GetClientBySessionId(string sessionId)
        {

            return WebSocketClientMg.Instance.GetClientBySessionId(sessionId);
        }
    }
}
