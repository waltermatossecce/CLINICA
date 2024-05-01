using CLINICA.Application.UseCase.UseCases.Results.Query.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CLINICA.Api.Extensions.Router.APIRouter;
namespace CLINICA.Api.Controllers
{
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ResultsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(RESULTS.ListadoResults)]
        public async Task<IActionResult> GetResults([FromQuery] GetAllResultsQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
