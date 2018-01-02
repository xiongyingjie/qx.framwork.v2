using System;
using System.Linq;

namespace qx.wechat.Models
{
    public class Msg
    {
        //文本消息-text
        public string Content;
        public string CreateTime;
        public string Description;

        //----------事件
        //取消关注事件-unsubscribe 
        //关注事件-subscribe         EventKey/qrscene_为前缀，后面为二维码的参数值
        //用户尝试重新关注事件-SCAN  EventKey/32位无符号整数，即创建二维码时的二维码scene_id
        //自定义菜单事件-CLICK       EventKey/与自定义菜单接口中KEY值对应
        //自定义菜单事件-VIEW       EventKey/与自定义菜单接口中URL值对应
        public string Event;
        public string EventKey;
        //语音消息-voice
        public string Format;
        public string FromUserName;
        public string Label;
        //上报地理位置事件-LOCATION
        public string Latitude;
        //地理位置消息-location
        public string Location_X;
        public string Location_Y;
        public string Longitude;

        //----------消息
        public string MediaId;
        public string MsgId;
        public string MsgType;
        //图片消息-image
        public string PicUrl;
        public string Precision;
        public string Scale;
        //视频消息-video  //小视频消息-shortvideo
        public string ThumbMediaId;
        public string Ticket;
        //链接消息-link
        public string Title;
        public string ToUserName;
        public string Url;

        public bool IsEvent
        {
            get
            {
                return
                    Enum.GetNames(typeof (EventTypeEnum))
                        .Any(a => string.Equals(a, Event, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public MsgTypeEnum GetMsgType()
        {
            if (MsgType.Length <= 0)
            {
                return MsgTypeEnum.NotMsg;
            }
            var type = MsgType.ToUpper()[0] + MsgType.Substring(1);
            return (MsgTypeEnum) Enum.Parse(typeof (MsgTypeEnum), type);
        }

        public EventTypeEnum GetEventType()
        {
            if (MsgType.Length <= 0)
            {
                return EventTypeEnum.NotEvent;
            }
            var type = MsgType.ToUpper();
            return (EventTypeEnum) Enum.Parse(typeof (EventTypeEnum), type);
        }



    }
}