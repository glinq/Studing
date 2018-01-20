using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocketService;

namespace WebSocketServices
{
    public class WebSocketServer
    {
        public static WebSocketKernel kernel;
        public static void Init(IApplicationBuilder app)
        {
            kernel = new WebSocketKernel(app);
            kernel.OnClientConnect += _OnConnect;
            kernel.OnClientClose += _OnClose;
            kernel.OnClientReceive += _OnReceive;
        }

        private static void _OnClose(object sender, DataEventArgs<string, WebSocketClient> e)
        {
            try
            {
                string str = string.Format("{0:HH:MM:ss} 客户端：{1} 与服务器：{2} 断开连接  sessionID:{3} ", DateTime.Now, e.Arg2.ClientIp + ":" + e.Arg2.ClientPort, e.Arg2.ServerIp + ":" + e.Arg2.ServerPort, e.Arg2.SessionId);
                var dic = kernel.GetAllClient();
            }
            catch (Exception ex)
            {
            }
            //清除缓存
        }

        private static void _OnConnect(object sender, DataEventArgs<string, WebSocketClient> e)
        {
            try
            {
                string str = string.Format("{0:HH:MM:ss} 客户端:{1} 与服务器：{2} 建立连接  sessionID:{3} ", DateTime.Now, e.Arg2.ClientIp + ":" + e.Arg2.ClientPort, e.Arg2.ServerIp + ":" + e.Arg2.ServerPort, e.Arg2.SessionId);
                var dic = kernel.GetAllClient();
            }
            catch (Exception ex)
            {

            }

        }

        private static void _OnReceive(object sender, DataEventArgs<string, WebSocketClient> e)
        {
            try
            {
                if (e != null && !string.IsNullOrEmpty(e.Arg1) && e.Arg2 != null)
                {
                    //如果是握手成功，主动拉取当前供应商待发送消息，
                    string str = string.Format("{0:HH:MM:ss} 客户端:{1} 向服务器：{2} 的  sessionID:{3} 发送消息：{4}", DateTime.Now, e.Arg2.ClientIp + ":" + e.Arg2.ClientPort, e.Arg2.ServerIp + ":" + e.Arg2.ServerPort, e.Arg2.SessionId, e.Arg1);

                    //存储客户端信息
                    string receiveContent = e.Arg1;
                    MessageRemindRequestModel requestModel = JsonConvert.DeserializeObject<MessageRemindRequestModel>(receiveContent);
                    if (requestModel == null)
                    {
                        return;
                    }
                    if (requestModel.Type == ClientMessageTypeEnum.FirstHand)//握手
                    {

                    }
                    else if (requestModel.Type == ClientMessageTypeEnum.Heart)//心跳包
                    {

                    }
                    else if (requestModel.Type == ClientMessageTypeEnum.MyMessage)//未读消息
                    {

                    }
                    else
                    {

                    }
                    var dic = kernel.GetAllClient();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
