using CLINICA.Application.UseCase.UseCases.Pacientes.Command.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.Pacientes.Command.CreateCommand;
using CLINICA.Application.UseCase.UseCases.Pacientes.Command.DeleteCommand;
using CLINICA.Application.UseCase.UseCases.Pacientes.Command.UpdateCommand;
using CLINICA.Application.UseCase.UseCases.Pacientes.Query.GetAllQuery;
using CLINICA.Application.UseCase.UseCases.Pacientes.Query.GetByIdQuery;
using CLINICA.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CLINICA.Api.Extensions.Router.APIRouter;

namespace CLINICA.Api.Controllers
{
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(PACIENTES.ListaPacientes)]
        public async Task<IActionResult> listaPacientes()
        {
            var response = await _mediator.Send(new GetAllPatientQuery());
            return Ok(response);    
        }

        [HttpGet(PACIENTES.PacientesById)]
        public async Task<IActionResult> PacientById(int patientId)
        {
            var response = await _mediator.Send(new GetPatientByIdQuery() { PatientId = patientId});
            return Ok(response);
        }
        [HttpPost(PACIENTES.PacientRegister)]
        public async Task<IActionResult> PacientRegister([FromBody] CreatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut(PACIENTES.PacientesUpdate)]
        public async Task<IActionResult> UpdatePacientes([FromBody] UpdatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete(PACIENTES.PacientesRemove)]
        public async Task<IActionResult>PacientRemove(int patientId)
        {
            var response = await _mediator.Send(new DeletePatientCommand() { PatientId = patientId});
            return Ok(response);
        }
        [HttpPut(PACIENTES.ChangeStatePatient)]
        public async Task<IActionResult> changeStatePatient([FromBody] ChangeStatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
