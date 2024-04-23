using AutoMapper;
using CLINICA.Application.Dtos.TakeExam.Response;
using CLINICA.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.Mappings
{
    public class TakeExamMappingProfile : Profile
    {
        public TakeExamMappingProfile()
        {
            CreateMap<GetTakeExamByIdResponseDto, TakeExam>()
                .ReverseMap();
           
            CreateMap<GetTakeExamDetailByTakeExamIdResponseDto,TakeExamDetail>()
                .ReverseMap();

            CreateMap<CreateTakeExamCommand, TakeExam>();

            CreateMap<CreateTakeExamDetailResponseDto, TakeExamDetail>();
        }
    }
}
