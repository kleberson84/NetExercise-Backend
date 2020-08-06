namespace NetExercise.BLL.Services.Abstract
{
    public interface IConvertService
    {
        string ConvertToXml(string text);
        string ConvertToCsv(string text);
    }
}
