using Microsoft.AspNetCore.Mvc;
using NetExercise.BLL.Services.Abstract;
using NetExercise.Web.API.Extensions;
using NetExercise.Web.API.Models;

namespace NetExercise.Web.API.Controllers
{
    [Route("api/convert")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly IConvertService _convertService;

        public ConvertController(IConvertService convertService)
        {
            _convertService = convertService;
        }

        [HttpPost]
        [Route("xml")]
        public TextWebModel ConvertToXml([FromBody] TextWebModel textWebModel)
        {
            return _convertService.ConvertToXml(textWebModel.Content)
                .ToTextWebModel();
        }

        [HttpPost]
        [Route("csv")]
        public TextWebModel ConvertToCsv([FromBody] TextWebModel textWebModel)
        {
            return _convertService.ConvertToCsv(textWebModel.Content)
                .ToTextWebModel();
        }
    }
}
