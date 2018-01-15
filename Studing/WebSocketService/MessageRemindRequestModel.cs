using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebSocketServices
{
    public class MessageRemindRequestModel
    {
        public ClientMessageTypeEnum Type { get; set; }

        public string ClientMessageInfo { get; set; }
    }
    /// <summary>
    /// 客户端消息类型
    /// </summary>
    public enum ClientMessageTypeEnum
    {
        [Description("首次握手信息")]
        FirstHand = 10001,
        [Description("心跳信息")]
        Heart = 10002,
        [Description("未读信息")]
        MyMessage = 10003
    }
}
