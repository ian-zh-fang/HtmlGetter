using com.tiger.ian.Configuration;
using System;

namespace com.tiger.ian.HtmlClient
{
    public class HttpClientSectionConfig
    {
        [ConfigurationSection(Name = "useragent", IsAttribute = true, AttributeName = "value")]
        public string UserAgent { get; set; }

        [ConfigurationSection(Name = "accept", IsAttribute = true, AttributeName = "value")]
        public string Accept { get; set; }

        [ConfigurationSection(Name = "cnzz", IsAttribute = true, AttributeName = "name")]
        public string CNZZName { get; set; }

        [ConfigurationSection(Name = "cnzz", IsAttribute = true, AttributeName = "value")]
        public string CNZZValue { get; set; }

        [ConfigurationSection(Name = "cnzz", IsAttribute = true, AttributeName = "path")]
        public string CNZZPath { get; set; }

        [ConfigurationSection(Name="token", IsAttribute=true, AttributeName="name")]
        public string TokenName { get; set; }

        [ConfigurationSection(Name = "token", IsAttribute = true, AttributeName = "value")]
        public string TokenValue { get; set; }

        [ConfigurationSection(Name = "session", IsAttribute = true, AttributeName = "name")]
        public string SessionName { get; set; }

        [ConfigurationSection(Name = "session", IsAttribute = true, AttributeName = "value")]
        public string SessionValue { get; set; }

        [ConfigurationSection(Name = "cookie", IsAttribute = true, AttributeName = "value")]
        public string CookieValue { get; set; }
    }
}
