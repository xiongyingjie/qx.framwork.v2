using System;
using System.Linq;

namespace qx.wechat.Models
{
    public class Msg
    {
        //�ı���Ϣ-text
        public string Content;
        public string CreateTime;
        public string Description;

        //----------�¼�
        //ȡ����ע�¼�-unsubscribe 
        //��ע�¼�-subscribe         EventKey/qrscene_Ϊǰ׺������Ϊ��ά��Ĳ���ֵ
        //�û��������¹�ע�¼�-SCAN  EventKey/32λ�޷�����������������ά��ʱ�Ķ�ά��scene_id
        //�Զ���˵��¼�-CLICK       EventKey/���Զ���˵��ӿ���KEYֵ��Ӧ
        //�Զ���˵��¼�-VIEW       EventKey/���Զ���˵��ӿ���URLֵ��Ӧ
        public string Event;
        public string EventKey;
        //������Ϣ-voice
        public string Format;
        public string FromUserName;
        public string Label;
        //�ϱ�����λ���¼�-LOCATION
        public string Latitude;
        //����λ����Ϣ-location
        public string Location_X;
        public string Location_Y;
        public string Longitude;

        //----------��Ϣ
        public string MediaId;
        public string MsgId;
        public string MsgType;
        //ͼƬ��Ϣ-image
        public string PicUrl;
        public string Precision;
        public string Scale;
        //��Ƶ��Ϣ-video  //С��Ƶ��Ϣ-shortvideo
        public string ThumbMediaId;
        public string Ticket;
        //������Ϣ-link
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