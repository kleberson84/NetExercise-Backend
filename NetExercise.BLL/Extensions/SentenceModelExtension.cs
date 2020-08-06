using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NetExercise.BLL.Models;

namespace NetExercise.BLL.Extensions
{
    public static class SentenceModelExtension
    {
        public static List<SentenceModel> ToSentenceModels(this List<string> sentences)
        {
            return sentences.Select(s =>
                {
                    var words = Regex.Replace(s, "[,\n]", String.Empty)
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
