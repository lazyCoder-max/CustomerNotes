using Application.Formulas.Commands.GetFormula;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [ApiController]
    public class FormulaController:ApiControllerBase
    {
        [Route("api/formula/get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormulas([FromQuery] GetAllFormulaCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
    }
}
