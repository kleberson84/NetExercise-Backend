using System;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using NetExercise.BLL.Extensions;
using NetExercise.BLL.Services.Abstract;
using NetExercise.BLL.Utils;

namespace NetExercise.BLL.Services
{
    internal class ConvertService : IConvertService
    {
        private const string CsvSeparator = ", ";

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

            try
            {
                using var stringWriter = new EncodedStringWriter(Encoding.UTF8);

                var longestSentence = model
                    .Sentences
                    .Max(s => s.Words.Count);

                var words = Enumerable.Range(1, longestSentence)
                    .Select(i => $"Word {i}")
                    .ToList();
                stringWriter.WriteLine(string.Join(CsvSeparator, words));

                var lines = Enumerable.Range(1, model.Sentences.Count)
                    .Select(i =>
                    {
                        words = model.Sentences[i - 1].Words;

                        return $"Sentence {i}, {string.Join(CsvSeparator, words)}";
                    })
                    .ToList();

                foreach (var line in lines)
                {
                    stringWriter.WriteLine(line);
                }

                return stringWriter.ToString();
            }
            catch (Exception e)
            {
                throw new Exception($"Error during converting text to CSV format: {e.Message}");
            }
        }
    }
}
