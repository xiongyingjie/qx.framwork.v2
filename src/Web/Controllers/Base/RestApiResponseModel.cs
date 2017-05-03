using System;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;

namespace Web.Controllers.Base
{
    public class RestApiResponseModel : RestApiResponse
    {
        public override void SetBody() { }
    }
    public abstract class RestApiResponse
    {
        protected RestApiResponse()
        {
            head = new Head()
            {
                //默认均为成功
                status = RestApiResponse.STATUS_SUCCESS
            };

        }
        protected static int STATUS_SUCCESS = 200;
        protected static int STATUS_FAILURE = 500;

        #region 返回给客户端的
        public object body;
        public Head head;
        #endregion
        public class Head
        {
            public int status;
        }
        public abstract void SetBody();

        public String ToJson()
        {
            SetBody();
            return new RestApiResponseModel() { head = head, body = body }.Serialize();
        }

        public ActionResult ToResult()
        {
            return new ContentResult()
            {
                Content = ToJson()
            };
        }
    }
}