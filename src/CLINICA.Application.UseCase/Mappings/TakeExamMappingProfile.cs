using AutoMapper;
using CLINICA.Application.Dtos.TakeExam.Response;
using CLINICA.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand;
using CLINICA.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using CLINICA.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand;
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

            CreateMap<CreateTakeExamDetailCommand, TakeExamDetail>();

            CreateMap<UpdateTakeExamCommand, TakeExam>();

            CreateMap<UpdateTakeExamDetailsCommand, TakeExamDetail>();

            CreateMap<ChangeStateTakeExamCommand, TakeExam>();
        
        }
    }
}
