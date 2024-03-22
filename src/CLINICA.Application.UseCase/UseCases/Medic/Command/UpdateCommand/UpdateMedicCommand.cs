using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Command.UpdateCommand
{
    public class UpdateMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int? MedicId { get; set; }
        public string? Names { get; set; }
        public string? Lastname { get; set; }
        public string? MotherMaidenName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? BithDate { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public int? SpecialtyId { get; set; }
    }
}
