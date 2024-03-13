using CLINICA.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.CreateCommands;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.DeleteCommands;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICA.Application.UseCase.UseCases.Analysis.Query.GetAllQuery;
using CLINICA.Application.UseCase.UseCases.Analysis.Query.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ListAnalysis()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());

            return Ok(response);
        }
        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery(){ AnalysisId = analysisId });

            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        [HttpPut("edit")]
        public async Task<IActionResult> EditAnlysis([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("Remove/{analysisId:int}")]
        public async Task<IActionResult>RemoveAnalysis(int analysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });
            return Ok(response);
        }
        [HttpPut("changeState")]
        public async Task<IActionResult> EditChangeState([FromBody] ChangeStateAnalysisCommand command)
        {
            var response =await _mediator.Send(command);
            return Ok(response);
        }
    }
}
