using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetExercise.BLL.Models
{
    [XmlRoot("text")]
    public class TextModel
    {
        [XmlElement("sentence")]
        public List<SentenceModel> Sentences { get; set; }
    }
}
