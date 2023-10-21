using System.Collections.Generic;
using System.Xml.Serialization;

namespace Xml2CSharp
{
    [XmlRoot(ElementName = "entry")]
    public class Entry
    {
        [XmlElement(ElementName = "timestamp")]
        public string dateTime { get; set; }
        [XmlElement(ElementName = "level")]
        public string errorType { get; set; }
        [XmlElement(ElementName = "message")]
        public string description { get; set; }
    }

    [XmlRoot(ElementName = "log")]
    public class Log
    {
        [XmlElement(ElementName = "entry")]
        public List<Entry> Entry { get; set; }
    }



}

