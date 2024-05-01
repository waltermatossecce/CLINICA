using CLINICA.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.CreateCommands;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.DeleteCommands;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICA.Application.UseCase.UseCases.Analysis.Query.GetAllQuery;
using CLINICA.Application.UseCase.UseCases.Analysis.Query.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static CLINICA.Api.Extensions.Router.APIRouter;

namespace CLINICA.Api.Controllers
{
    [ApiController]
    [EnableCors("Cors")]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(ANALISTC.listadoAnalysis)]
        public async Task<IActionResult> ListAnalysis([FromQuery] GetAllAnalysisQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet(ANALISTC.AnalysisById)]
        public async Task<IActionResult> AnalysisById(int analysisId) => Ok(await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId }));
    
        [HttpPost(ANALISTC.Register)]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        [HttpPut(ANALISTC.EditarAnalysis)]
        public async Task<IActionResult> EditAnlysis([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete(ANALISTC.RemoveAnalysis)]
        public async Task<IActionResult> RemoveAnalysis(int analysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });
            return Ok(response);
        }
        [HttpPut(ANALISTC.UpdateStateAnalysis)]
        public async Task<IActionResult> EditChangeState([FromBody] ChangeStateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
