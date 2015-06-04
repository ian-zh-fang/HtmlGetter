using com.tiger.ian.Configuration;
using System;

namespace com.tiger.ian.HtmlClient
{
    public sealed class SimpleHttpClient : HttpClient
    {

        public new event Action<System.Net.HttpWebRequest> onDoing
        {
            add { base.onDoing += value; }
            remove { base.onDoing -= value; }
        }

        public new event Action<Exception> onDoError
        {
            add { base.onDoError += value; }
            remove { base.onDoError -= value; }
        }
        
        public new event Action<System.Net.HttpWebResponse> onDone
        {
            add { base.onDone += value; }
            remove { base.onDone -= value; }
        }

        public static event Action onReadingConfig;
        public static event Action<HttpClientSectionConfig> onReadedConfig;

        private static readonly string DEFAULTSECTIONNAME;        

        static SimpleHttpClient()
        {
            if (null != onReadingConfig)
                onReadingConfig();

            DEFAULTSECTIONNAME = "httpclientconf";
            DefaultConfigurationReader reader = new DefaultConfigurationReader();
            HttpClientSectionConfig config = reader.GetSection<HttpClientSectionConfig>(DEFAULTSECTIONNAME);
            DEFAULTUSERAGENT = config.UserAgent;
            DEFAULTACCEPT = config.Accept;
            CNZZDATANAME = config.CNZZName;
            CNZZDATAVALUE = config.CNZZValue;
            CNZZDATAPATH = config.CNZZPath;
            DEFAULTSESSIONNAME = config.SessionName;
            DEFAULTSESSIONVALUE = config.SessionValue;
            DEFAULTTOKENNAME = config.TokenName;
            DEFAULTTOKENVALUE = config.TokenValue;
            TESTCOOKIE = config.CookieValue;
            

            if (null != onReadedConfig)
                onReadedConfig(config);
        }
    }
}
