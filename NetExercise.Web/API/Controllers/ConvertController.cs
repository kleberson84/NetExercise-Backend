using Microsoft.AspNetCore.Http;
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
        public IActionResult ConvertToXml([FromBody] TextWebModel textWebModel)
        {
            if (string.IsNullOrWhiteSpace(textWebModel.Content) || !textWebModel.IsValid())
            {
                return BadRequest( new { error = "This field can contain letters, digits, comma and dot characters and can't be empty" });
            }

            var result = _convertService.ConvertToXml(textWebModel.Content);

            if (result.Failure)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { error = result.Error });
            }

            return Ok(result.Value.ToTextWebModel());
        }

        [HttpPost]
        [Route("csv")]
        public IActionResult ConvertToCsv([FromBody] TextWebModel textWebModel)
        {
            if (string.IsNullOrWhiteSpace(textWebModel.Content) || !textWebModel.IsValid())
            {
                return BadRequest(new { error = "This field can contain letters, digits, comma and dot characters and can't be empty" });
            }

            var result = _convertService.ConvertToCsv(textWebModel.Content);

            if (result.Failure)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { error = result.Error });
            }

            return Ok(result.Value.ToTextWebModel());
        }
    }
}
