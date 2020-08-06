using System.Text.RegularExpressions;
using NetExercise.Web.API.Models;

namespace NetExercise.Web.API.Extensions
{
    public static class TextWebModelExtension
    {
        public static TextWebModel ToTextWebModel(this string text)
        {
            return new TextWebModel
            {
                Content = text
            };
        }

        public static bool IsValid(this TextWebModel model)
        {
            return Regex.IsMatch(model.Content, @"^[a-zA-Z0-9]+[a-zA-Z0-9,.\s\r\n]*$");
        }
    }
}
