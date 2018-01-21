using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace WebSocketSimpleService
{
    public class Client
    {
        public WebSocket WebSocket;

        private IApplicationBuilder _app;

        private Dictionary<string, WebSocket> UserDic = new Dictionary<string, WebSocket>();

        private Dictionary<string, MessageInfo> UserMessage = new Dictionary<string, MessageInfo>();

        public Client(IApplicationBuilder app)
        {
            _app = app;
            //_app.Use(async (context, next) => {
            //    if(context.WebSockets.IsWebSocketRequest)
            //    {
            //        WebSocket =await context.WebSockets.AcceptWebSocketAsync();

            //        if(UserDic.Keys.Contains(context.Session))
            //        {

            //        }














            //    }
            //    else
            //    {
            //       await next();
            //    }
                

            //});
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
