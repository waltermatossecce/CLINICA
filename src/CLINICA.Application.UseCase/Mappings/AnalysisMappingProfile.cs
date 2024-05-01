using AutoMapper;
using CLINICA.Application.Dtos.Analysis.Response;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.CreateCommands;
using CLINICA.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                 .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                 .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();

            CreateMap<UpdateAnalysisCommand, Analysis>();

            CreateMap<ChangeStateAnalysisCommand, Analysis>();
        }
    }
}
