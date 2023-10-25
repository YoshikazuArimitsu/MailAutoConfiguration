using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MailAutoConfigurationLib.Models
{
    /// <summary>
    /// https://wiki.mozilla.org/Thunderbird:Autoconfiguration:ConfigFileFormat
    /// </summary>
    [XmlRoot("clientConfig")]
    public class ConfigFileFormat
    {
        [XmlElement("emailProvider")]
        public List<EmailProvider> EmailProviders { get; set; } = new List<EmailProvider>();
    }

    public class EmailProvider
    {
        [XmlElement("displayName")]
        public string? DisplayName { get; set; }
        [XmlElement("displayShortName")]
        public string? DisplayShortName { get; set; }

        [XmlElement("domain")]
        public List<string> Domains { get; set; } = new List<string>();


        [XmlElement("incomingServer")]
        public IncomingServer? IncomingServer { get; set; }

        [XmlElement("outgoingServer")]
        public OutgoingServer? OutgoingServer { get; set; }
    }

    public class IncomingServer
    {

    }

    public class OutgoingServer
    {

    }

}
