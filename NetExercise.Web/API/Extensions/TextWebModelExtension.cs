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
    }
}
