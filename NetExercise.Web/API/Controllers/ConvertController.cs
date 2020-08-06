using Microsoft.AspNetCore.Mvc;
using NetExercise.Web.API.Models;

namespace NetExercise.Web.API.Controllers
{
    [Route("api/convert")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        [HttpPost]
        [Route("xml")]
        public TextWebModel ConvertToXml([FromBody] TextWebModel textWebModel)
        {
            return new TextWebModel
            {
                Content = string.Empty
            };
        }

        [HttpPost]
        [Route("csv")]
        public TextWebModel ConvertToCsv([FromBody] TextWebModel textWebModel)
        {
            return new TextWebModel
            {
                Content = string.Empty
            };
        }
    }
}
