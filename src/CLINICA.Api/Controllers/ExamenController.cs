using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Application.UseCase.UseCases.Examen.Command.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.Examen.Command.CreateCommand;
using CLINICA.Application.UseCase.UseCases.Examen.Command.DeleteCommand;
using CLINICA.Application.UseCase.UseCases.Examen.Command.UpdateCommand;
using CLINICA.Application.UseCase.UseCases.Examen.Query.GetAllQuery;
using CLINICA.Application.UseCase.UseCases.Examen.Query.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CLINICA.Api.Extensions.Router.APIRouter;

namespace CLINICA.Api.Controllers
{

    [ApiController]
    public class ExamenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(EXAMEN.ListaExamen)]
        public async Task<IActionResult> ListaExamen()
        {
            var response = await _mediator.Send(new GetAllExamenQuery());
            return Ok(response);
        }
        [HttpGet(EXAMEN.ExamenById)]
        public async Task<IActionResult>ExamenById(int examId)
        {
            var response = await _mediator.Send(new GetExamenByIdQuery() { ExamId = examId});
            return Ok(response);
        }
        [HttpPost(EXAMEN.ExamenRegister)]
        public async Task<IActionResult> ExamenRegister([FromBody] CreateExamenCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut(EXAMEN.UpdateExamen)]
        public async Task<IActionResult> ActualizaExamen([FromBody] UpdateExamenCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete(EXAMEN.DeleteExamen)]
        public async Task<IActionResult> EliminarExamen(int examId)
        {
            var response = await _mediator.Send(new DeleteExamenCommand() { ExamId = examId});
            return Ok(response);
        }
        [HttpPut(EXAMEN.ChangeStateExamen)]
        public async Task<IActionResult> EditarEstadoDelExamen([FromBody] ChangeStateExamenCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);    
        }

    }
}
