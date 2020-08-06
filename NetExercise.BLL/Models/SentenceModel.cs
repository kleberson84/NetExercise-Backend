using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetExercise.BLL.Models
{
    public class SentenceModel
    {
        [XmlElement("word")]
        public List<string> Words { get; set; }
    }
}
