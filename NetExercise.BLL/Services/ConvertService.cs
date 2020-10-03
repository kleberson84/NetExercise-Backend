using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using NetExercise.BLL.Models;
using NetExercise.BLL.Services.Abstract;
using NetExercise.BLL.Utils;

namespace NetExercise.BLL.Services
{
    public class ConvertService : IConvertService
    {
        private const string CsvSeparator = ", ";

        public Result<string> ConvertToXml(string text)
        {
            var model = ParseToTextModel(text);

            try
            {
                using var stringWriter = new StringWriter();

                var xmlNamespaces = new XmlSerializerNamespaces();
                xmlNamespaces.Add("", "");

                var xmlSerializer = new XmlSerializer(model.GetType());
                xmlSerializer.Serialize(stringWriter, model, xmlNamespaces);

                return Result.Ok(stringWriter.ToString());
            }
            catch (Exception e)
            {
                return Result.Fail<string>( $"Error during converting text to XML format: {e.Message}");
            }
        }

        public Result<string> ConvertToCsv(string text)
        {
            var model = ParseToTextModel(text);

            if (!model.Sentences.Any())
            {
                return Result.Ok(string.Empty);
            }

            try
            {
                using var stringWriter = new StringWriter();

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

                return Result.Ok(stringWriter.ToString());
            }
            catch (Exception e)
            {
                return Result.Fail<string>($"Error during converting text to CSV format: {e.Message}");
            }
        }

        private TextModel ParseToTextModel(string text)
        {
            var sentencesList = text
                .Trim()
                .Split('.', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            return new TextModel
            {
                Sentences = ParseToSentenceModels(sentencesList)
            };
        }

        private List<SentenceModel> ParseToSentenceModels(List<string> sentences)
        {
            return sentences
                .Select(s =>
                {
                    var words = Regex.Replace(s, "[,\r\n]", " ")
                        .Trim()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    words.Sort();

                    return new SentenceModel
                    {
                        Words = words
                    };
                })
                .ToList();
        }
    }
}
