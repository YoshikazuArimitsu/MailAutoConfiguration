using MailAutoConfigurationLib.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace MailAutoConfigurationLib
{
    public class MailAutoConfiguration
    {
        private IEnumerable<string> LocalPaths { get; set; } = new List<string>();


        public ConfigFileFormat? ParseXML(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigFileFormat));

            using (var reader = new StringReader(xml))
            {
                return serializer.Deserialize(reader) as ConfigFileFormat;
            }
        }

        private Task<ConfigFileFormat?> tryParseConfigurationUrlAsync(string url)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigFileFormat));

            using (var reader = XmlReader.Create(url))
            {
                var config = serializer.Deserialize(reader) as ConfigFileFormat;
                return Task.FromResult(config);
            }
        }

        public async Task<ConfigFileFormat?> SearchAsync(string emailAddress)
        {
            if(emailAddress.IndexOf("@") == -1)
            {
                throw new ArgumentException("Invalid emailAddress format");
            }

            var domain = emailAddress.Substring(emailAddress.IndexOf("@") + 1);

            var paths = LocalPaths.Select(p => $"{p}/{domain}.xml");
            var urls = new string[] {
                $"http://autoconfig.{domain}/mail/config-v1.1.xml?emailaddress={emailAddress}",
                $"http://{domain}/.well-known/autoconfig/mail/config-v1.1.xml",
                $"https://live.mozillamessaging.com/autoconfig/v1.1/{domain}",
            };

            var pathUrls = paths.Concat(urls);

            foreach(var url in pathUrls)
            {
                try
                {
                    var config = await tryParseConfigurationUrlAsync(url);

                    if(config != null)
                    {
                        return config;
                    }
                } catch(Exception)
                {

                }
            }

            return null;
        }
    }
}
