using CLINICA.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using CLINICA.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand;
using CLINICA.Application.UseCase.UseCases.TakeExam.Query.GetAllQuery;
using CLINICA.Application.UseCase.UseCases.TakeExam.Query.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CLINICA.Api.Extensions.Router.APIRouter;

namespace CLINICA.Api.Controllers
{
    [ApiController]
    public class TakeExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TakeExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(TAKEEXAM.ListadoTakeExam)]
        public async Task<IActionResult> listaTakeExam([FromQuery] GetAllTakeExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(TAKEEXAM.TakeExamById)]
        public async Task<IActionResult> TakeExamById(int takeExamId)
        {
            var response = await _mediator.Send(new GetTakeExamByIdQuery() { TakeExamById = takeExamId });

            return Ok(response);
        }
        [HttpPost(TAKEEXAM.RegisterTakeExam)]
        public async Task<IActionResult> RegisterTakeExam([FromBody] CreateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut(TAKEEXAM.UpdateTakeExam)]
        public async Task<IActionResult> UpdateTakeExam([FromBody] UpdateTakeExamCommand command)
        {
            var response =await _mediator.Send(command);
            return Ok(response);
        
        }
        [HttpPut(TAKEEXAM.ChangeStateTakeExam)]
        public async Task<IActionResult>ChangeStateTakeExam([FromBody] ChangeStateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
