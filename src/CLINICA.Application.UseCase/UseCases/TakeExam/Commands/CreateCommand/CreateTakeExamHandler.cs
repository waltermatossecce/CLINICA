using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Domain.Entities;
using CLINICA.Utilities.Constantes;
using MediatR;
using Entity = CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand
{
    public class CreateTakeExamHandler : IRequestHandler<CreateTakeExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateTakeExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                var takeExam = _mapper.Map<Entity.TakeExam>(request);
                var takeExamRegis = await _unitOfWork.TakeExam.RegisterTakeExam(takeExam);

                foreach (var detail in takeExamRegis.TakeExamDetails)
                {
                    var newTakeExamDetails = new TakeExamDetail
                    {
                        TakeExamId = detail.TakeExamId,
                        ExamId = detail.ExamId,
                        AnalysisId = detail.AnalysisId,
                    };
                    await _unitOfWork.TakeExam.RegisterTakeExamDetail(newTakeExamDetails);
                }
                transaction.Complete();
                response.IsSucess = true;
                response.Message = GlobalMessage.MESSAGE_SAVE;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
