using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Pacientes.Command.UpdateCommand
{
    public class UpdatePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int? PatientId { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? MotherMaidenName { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Phono { get; set; }
        public int? TypeAgeId { get; set; }
        public int? Age { get; set; }
        public int? GenerId { get; set; }
    }
}
