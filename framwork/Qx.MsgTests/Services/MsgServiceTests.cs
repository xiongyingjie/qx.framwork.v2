using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qx.Msg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Msg.Services.Tests
{
    [TestClass()]
    public class MsgServiceTests
    {
        [TestMethod()]
        public void MyInBoxMsgTest()
        {
            MsgService msg_service = new MsgService();
            Assert.IsNotNull(msg_service.MyInBoxMsg("001"));
        }
    }
}