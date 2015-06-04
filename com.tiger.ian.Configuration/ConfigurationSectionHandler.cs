using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tiger.ian.Configuration
{
    public abstract class ConfigurationSectionHandler : System.Configuration.IConfigurationSectionHandler
    {
        object System.Configuration.IConfigurationSectionHandler.Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            return Create(parent, configContext, section);
        }

        protected abstract object Create(object parent, object configContext, System.Xml.XmlNode section);
    }

    public abstract class ConfigurationSectionHandler<T> : ConfigurationSectionHandler where T : class, new()
    {
        protected override object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            return Build(parent, configContext, section);
        }

        protected virtual T Build(object parent, object configContext, System.Xml.XmlNode section)
        {
            return Build(section, typeof(T)) as T;
        }

        protected abstract object Build(System.Xml.XmlNode node, Type tp);
    }
}
