using System.Text.RegularExpressions;
using NetExercise.Web.API.Models;

namespace NetExercise.Web.API.Validators
{
    public static class TextWebModelValidator
    {
        public static bool IsValid(this TextWebModel model)
        {
            return Regex.IsMatch(model.Content.Trim(), @"^[a-zA-Z0-9]+[a-zA-Z0-9,.\s\r\n]*$");
        }
    }
}
