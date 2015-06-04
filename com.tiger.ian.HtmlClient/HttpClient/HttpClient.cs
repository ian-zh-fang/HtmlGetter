using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using com.tiger.ian.Utility;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace com.tiger.ian.HtmlClient
{
    public abstract class HttpClient
    {
        public event Action<HttpWebRequest> onDoing;
        public event Action<Exception> onDoError;
        public event Action<HttpWebResponse> onDone;
        protected static string DEFAULTUSERAGENT;
        protected static string DEFAULTACCEPT;
        protected static string CNZZDATANAME;
        protected static string CNZZDATAVALUE;
        protected static string CNZZDATAPATH;
        protected static CookieContainer mCookie;
        protected static string DEFAULTTOKENNAME;
        protected static string DEFAULTTOKENVALUE;
        protected static string DEFAULTSESSIONNAME;
        protected static string DEFAULTSESSIONVALUE;
        protected static string TESTCOOKIE;


        private static Cookie mCNZZDATACOOKIE;
        private static string TOKENNAME = "cgtz_token";
        private static string PHPSESSIDNAME = "PHPSESSID";

        private string mToken;
        private string mPhpsessid;

        /// <summary>
        /// 发送 HttpWebRequest 请求，返回服务器响应数据
        /// </summary>
        /// <param name="url">远程服务器数据请求地址</param>
        /// <param name="method">请求方式，枚举类型 MethodType 的值之一。</param>
        /// <param name="parameters">请求参数信息。</param>
        /// <returns>返回服务器响应数据</returns>
        public string Request(string url, MethodType method, ParamCollection parameters, bool flag = false)
        {
            HttpWebRequest request = Create(url, method, parameters);
            string responseText = Receive(request, flag).Result;
            return responseText;
        }

        public string Request(string url = "https://www.cgtz.com/user/index")
        {
            HttpWebRequest request = Create(url);
            string responseText = Receive(request, false).Result;
            return responseText;
        }

        /// <summary>
        /// 根据指定类型实例的参数形式，并返回 ParamCollection 的一个实例
        /// </summary>
        /// <typeparam name="T">指定的运行时类型</typeparam>
        /// <param name="t">指定运行时类型的一个实例</param>
        /// <returns>返回 ParamCollection 的一个实例</returns>
        protected virtual ParamCollection CreateParamCollection<T>(T t)
        { 
            Type tp = typeof(T);
            PropertyInfo[] properties = tp.GetProperties();
            ParamCollection parameters = new ParamCollection();
            int len = properties.Length;
            PropertyInfo property = null;
            for (int i = 0; i < len; i++)
            {
                if ((property = properties[i]).CanRead)
                {
                    object val = property.GetValue(t, null);
                    parameters.Add(property.Name, string.Format("{0}", val));
                }
            }
            return parameters;
        }

        protected virtual async Task<string> Receive(HttpWebRequest request, bool flag)
        {

            HttpWebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;
            string val = null;

            try
            {
                if (null != onDoing)
                    onDoing(request);
                //此处等待请求响应

                string cookie = request.Headers["Cookie"];
                string len = request.Headers["Content-Length"];
                string referer = request.Headers["Referer"];
                
                response = await Task.Factory.StartNew(() => (HttpWebResponse)request.GetResponse());

                Cookie token = response.Cookies[TOKENNAME];
                if (flag && null != token)
                    mToken = token.Value;

                Cookie session = response.Cookies[PHPSESSIDNAME];
                if (flag && null != session)
                    mPhpsessid = session.Value;

                ResetCookie(response.Headers);
                 
                //从此处开始读取请求的数据
                stream = response.GetResponseStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                val = reader.ReadToEnd();

                if (null != onDone)
                    onDone(response);
            }
            catch (Exception e) 
            {
                if (null != onDoError)
                    onDoError(e);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }

                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }

                if (response != null)
                {
                    response.Close();
                    response.Dispose();
                }
            }

            return val;
        }

        private void ResetCookie(WebHeaderCollection headers)
        {
            string cookieHeader = headers["Set-Cookie"];
            if (string.IsNullOrWhiteSpace(cookieHeader))
                return;

            //string[] settings = cookieHeader.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            //string settingstr = settings.FirstOrDefault(t => t.StartsWith(PHPSESSIDNAME));
            //if (!string.IsNullOrWhiteSpace(settingstr))
            //    mPhpsessid = settingstr.Split('=')[1];

            //settingstr = settings.FirstOrDefault(t => t.StartsWith(TOKENNAME));
            //if (!string.IsNullOrWhiteSpace(settingstr))
            //    mToken = settingstr.Split('=')[1];
        }

        /// <summary>
        /// 创建 HttpWebRequest 请求实例。
        /// </summary>
        /// <param name="url">请求地址。</param>
        /// <param name="method">请求方式，枚举类型 MethodType 的值之一。</param>
        /// <param name="parameters">请求参数信息。</param>
        /// <returns>返回 HttpWebRequest 的一个实例</returns>
        protected virtual HttpWebRequest Create(string url, MethodType method, ParamCollection parameters)
        {
            HttpWebRequest request = null;
            parameters = parameters ?? new ParamCollection();
            switch (method)
            { 
                case MethodType.Get:
                    url = string.Format("{0}{1}", url, 0 == parameters.Count ? null : string.Format("?{0}", parameters.ToString()));
                    request = HttpWebRequest.CreateHttp(url);
                    request.ContentType = "text/html; charset=UTF-8";
                    request.Method = "GET";
                    request.ContentLength = 0L;
                    request.Headers.Add("Cookie", GetHeaderCookie());
                    request.CookieContainer = (mCookie = new CookieContainer());
                    break;
                case MethodType.Post:
                default:
                    request = HttpWebRequest.CreateHttp(url);
                    request.Method = "POST";
                    request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
                    request.Headers.Add("Cookie", GetHeaderCookie());
                    request.Referer = "https://www.cgtz.com/user/index";
                    request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";                    
                    WriteParamToStream(parameters, ref request);
                    break;
            }
            request.KeepAlive = true;
            request.Timeout = 50000;
            request.AllowAutoRedirect = true;
            request.UserAgent = DEFAULTUSERAGENT;
            request.Accept = DEFAULTACCEPT;
            SetCertificatePolicy();

            return request;
        }

        protected virtual HttpWebRequest Create(string url)
        {
            HttpWebRequest request;
            request = HttpWebRequest.CreateHttp(url);
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            //request.ContentType = "text/html";
            request.Method = "GET";
            //request.ContentLength = -1;
            request.Headers.Add("Cookie", TESTCOOKIE);
            request.CookieContainer = new CookieContainer();
            request.KeepAlive = true;
            request.Timeout = 50000;
            request.AllowAutoRedirect = true;
            request.UserAgent = DEFAULTUSERAGENT;
            request.Accept = DEFAULTACCEPT;
            SetCertificatePolicy();

            return request;
        }

        private string GetHeaderCookie()
        {
            return string.Join(";", new string[]
            {
                string.Format("{0}={1}", CNZZDATANAME, CNZZDATAVALUE),
                string.Format("{0}={1}", TOKENNAME, mToken),
                string.Format("{0}={1}", PHPSESSIDNAME, mPhpsessid)
            });
        }

        /// <summary>
        /// 向 HttpWebRequest 请求正文中添加参数信息
        /// </summary>
        /// <param name="parameters">参数集合信息</param>
        /// <param name="request">HttpWebRequest 请求实例</param>
        protected virtual void WriteParamToStream(ParamCollection parameters, ref HttpWebRequest request)
        {
            string paramstr = parameters.ToString();
            byte[] buffer = Encoding.UTF8.GetBytes(paramstr);
            int len = buffer.Length;

            request.ContentLength = len;
            using(Stream stream = request.GetRequestStream())
            {
                stream.Write(buffer, 0, len);
                stream.Close();
            }
        }

        /// <summary>
        /// 注册证书验证回调事件，在请求之前注册
        /// </summary>
        private void SetCertificatePolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback
                       += RemoteCertificateValidate;
        }
        
        /// <summary>  
        /// 远程证书验证，固定返回true 
        /// </summary>  
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert,
            X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }  
    }

    /// <summary>
    /// 请求方式
    /// </summary>
    public enum MethodType : int
    {
        /// <summary>
        /// 
        /// </summary>
        Post = 0x00,
        /// <summary>
        /// 
        /// </summary>
        Get = 0x01
    }
}
