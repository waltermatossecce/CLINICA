using AutoMapper;
using CLINICA.Application.UseCase.UseCases.Results.Query.GetAllQuery;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.Mappings
{
    public class ResultsMappingProfile :Profile
    {
        public ResultsMappingProfile()
        {
            CreateMap<GetAllResultsQuery,Results>()
                .ReverseMap();
        }
    }
}
