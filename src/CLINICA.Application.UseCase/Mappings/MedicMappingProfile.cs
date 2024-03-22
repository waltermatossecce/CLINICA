using AutoMapper;
using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Application.UseCase.UseCases.Medic.Command.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.Medic.Command.CreateCommand;
using CLINICA.Application.UseCase.UseCases.Medic.Command.UpdateCommand;
using CLINICA.Application.UseCase.UseCases.Medic.Query.GetByIdQuery;
using CLINICA.Application.UseCase.UseCases.Pacientes.Command.CreateCommand;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.Mappings
{
    public class MedicMappingProfile : Profile
    {
        public MedicMappingProfile()
        {
            CreateMap<GetMedicByIdResponseDto, Medic>()
                .ReverseMap();

            CreateMap<CreateMedicCommand, Medic>();

            CreateMap<UpdateMedicCommand,Medic>();

            CreateMap<ChangeStateMedicCommand, Medic>();
        }
    }
}
