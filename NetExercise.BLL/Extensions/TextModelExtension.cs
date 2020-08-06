using System;
using System.Linq;
using NetExercise.BLL.Models;

namespace NetExercise.BLL.Extensions
{
    public static class TextModelExtension
    {
        public static TextModel ToTextModel(this string text)
        {
            return new TextModel
            {
                Sentences = text
                    .Split('.', StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ToSentenceModels()
            };
        }
    }
}
