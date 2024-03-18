using AutoMapper;
using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Application.UseCase.UseCases.Examen.Command.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.Examen.Command.CreateCommand;
using CLINICA.Application.UseCase.UseCases.Examen.Command.DeleteCommand;
using CLINICA.Application.UseCase.UseCases.Examen.Command.UpdateCommand;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.Mappings
{
    public class ExamenMappingProfile :Profile
    {
        public ExamenMappingProfile()
        {
            CreateMap<Examen, GetExamenByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateExamenCommand, Examen>();

            CreateMap<UpdateExamenCommand, Examen>();

            CreateMap<DeleteExamenCommand, Examen>();

            CreateMap<ChangeStateExamenCommand, Examen>();
        }
    }
}
