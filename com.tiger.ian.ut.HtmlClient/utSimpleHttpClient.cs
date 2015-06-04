using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.tiger.ian.HtmlClient;

namespace com.tiger.ian.ut.HtmlClient
{
    [TestClass]
    public class utSimpleHttpClient
    {
        [TestMethod]
        public void getHttpClientConfig()
        {
            SimpleHttpClient client = new SimpleHttpClient();
            Assert.IsNotNull(client);
        }
    }
}
