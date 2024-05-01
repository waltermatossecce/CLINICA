using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Domain.Entities;
using CLINICA.Utilities.Constantes;
using MediatR;
using Entidad = CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand
{
    public class UpdateTakeExamHandler : IRequestHandler<UpdateTakeExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateTakeExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                //mapeamos nuestro command
                var takeExamen = _mapper.Map<Entidad.TakeExam>(request);
                
                await _unitOfWork.TakeExam.EditTakeExam(takeExamen);
                foreach(var details in request.takeExamDetails)
                {
                    var editTakeExamDetails = new TakeExamDetail
                    {
                        AnalysisId = details.AnalysisId,
                        ExamId = details.ExamId,
                        TakeExamDetailId = details.TakeExamDetailId,
                    };
                    await _unitOfWork.TakeExam.EditTakeExamDetails(editTakeExamDetails);
                }
                transaction.Complete();
                response.IsSucess = true;
                response.Message = GlobalMessage.MESSAGE_UPDATE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
