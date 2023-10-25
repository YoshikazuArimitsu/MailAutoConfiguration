using MailAutoConfigurationLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MailAutoConfigurationLib
{
    public class MailAutoConfiguration
    {
        public ConfigFileFormat? ParseXML(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigFileFormat));

            using (var reader = new StringReader(xml))
            {
                return serializer.Deserialize(reader) as ConfigFileFormat;
            }

        }
    }
}
