using System;
using System.Text;
using System.Xml.Serialization;
using NetExercise.BLL.Extensions;
using NetExercise.BLL.Services.Abstract;
using NetExercise.BLL.Utils;

namespace NetExercise.BLL.Services
{
    internal class ConvertService : IConvertService
    {
        public string ConvertToXml(string text)
        {
            var model = text.ToTextModel();

            try
            {
                using var stringWriter = new EncodedStringWriter(Encoding.UTF8);

                var xmlNamespaces = new XmlSerializerNamespaces();
                xmlNamespaces.Add("", "");

                var xmlSerializer = new XmlSerializer(model.GetType());
                xmlSerializer.Serialize(stringWriter, model, xmlNamespaces);

                return stringWriter.ToString();
            }
            catch (Exception e)
            {
                throw new Exception($"Error during converting text to XML format: {e.Message}");
            }
        }

        public string ConvertToCsv(string text)
        {
            var model = text.ToTextModel();

            return text;
        }
    }
}
