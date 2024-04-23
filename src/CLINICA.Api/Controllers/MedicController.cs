using CLINICA.Application.UseCase.UseCases.Medic.Command.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.Medic.Command.CreateCommand;
using CLINICA.Application.UseCase.UseCases.Medic.Command.DeleteCommad;
using CLINICA.Application.UseCase.UseCases.Medic.Command.UpdateCommand;
using CLINICA.Application.UseCase.UseCases.Medic.Query.GetAllQuery;
using CLINICA.Application.UseCase.UseCases.Medic.Query.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CLINICA.Api.Extensions.Router.APIRouter;

namespace CLINICA.Api.Controllers
{
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(MEDICOS.ListaMedicos)]
        public async Task<IActionResult> listaMedic([FromQuery] GetAllMedicQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(MEDICOS.MedicosById)]
        public async Task<IActionResult>MedicosPorId(int medicId)
        {
            var response = await _mediator.Send(new GetMedicByIdQuery() { MedicId = medicId});
            return Ok(response);
        }
        [HttpPost(MEDICOS.MedicRegister)]
        public async Task<IActionResult> MedicRegister([FromBody] CreateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut(MEDICOS.MedicUpdate)]
        public async Task<IActionResult> UpdateMedic([FromBody]UpdateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete(MEDICOS.MedicDelete)]
        public async Task<IActionResult> DeleteMedic(int medicId)
        {
            var response = await _mediator.Send(new DeleteMedicCommand() { MedicId = medicId });
            return Ok(response);    
        }
        [HttpPut(MEDICOS.ChangeStateMedic)]
        public async Task<IActionResult> ChangeStateMedic([FromBody] ChangeStateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
