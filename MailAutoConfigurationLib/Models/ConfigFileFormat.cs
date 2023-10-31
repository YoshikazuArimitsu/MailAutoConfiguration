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

        [XmlElement("oAuth2")]
        public OAuth2? OAuth2 { get; set; }
    }

    public class OAuth2
    {
        [XmlElement("issuer")]
        public string? Issuer { get; set; }

        [XmlElement("scope")]
        public string? Scope { get; set; }

        [XmlElement("authURL")]
        public string? AuthURL { get; set; }

        [XmlElement("tokenURL")]
        public string? TokenURL { get; set; }
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
        public List<IncomingServer>? IncomingServer { get; set; }

        [XmlElement("outgoingServer")]
        public List<OutgoingServer>? OutgoingServer { get; set; }
    }

    public class IncomingServer
    {
        [XmlAttribute("type")]
        public string? Type { get; set; }

        [XmlElement("hostname")]
        public string? Hostname { get; set; }

        [XmlElement("port")]
        public int? Port { get; set; }

        [XmlElement("socketType")]
        public string? SocketType { get; set; }

        [XmlElement("username")]
        public string? Username { get; set; }

        [XmlElement("authentication")]
        public string? Authentication { get; set; }
    }

    public class Pop3
    {
        [XmlElement("leaveMessagesOnServer")]
        public string? LeaveMessagesOnServer { get; set; }
    }

    public class OutgoingServer
    {
        [XmlAttribute("type")]
        public string? Type { get; set; }

        [XmlElement("hostname")]
        public string? Hostname { get; set; }

        [XmlElement("socketType")]
        public string? SocketType { get; set; }

        [XmlElement("username")]
        public string? Username { get; set; }

        [XmlElement("authentication")]
        public string? Authentication { get; set; }
    }

}
