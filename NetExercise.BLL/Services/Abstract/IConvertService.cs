using NetExercise.BLL.Utils;

namespace NetExercise.BLL.Services.Abstract
{
    public interface IConvertService
    {
        Result<string> ConvertToXml(string text);
        Result<string> ConvertToCsv(string text);
    }
}
