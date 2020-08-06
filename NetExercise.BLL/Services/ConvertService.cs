using NetExercise.BLL.Extensions;
using NetExercise.BLL.Services.Abstract;

namespace NetExercise.BLL.Services
{
    internal class ConvertService : IConvertService
    {
        public string ConvertToXml(string text)
        {
            var model = text.ToTextModel();

            return text;
        }

        public string ConvertToCsv(string text)
        {
            var model = text.ToTextModel();

            return text;
        }
    }
}
