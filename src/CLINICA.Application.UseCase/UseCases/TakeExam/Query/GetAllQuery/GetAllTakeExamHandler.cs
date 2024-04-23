using CLINICA.Application.Dtos.TakeExam.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Query.GetAllQuery
{
    public class GetAllTakeExamHandler : IRequestHandler<GetAllTakeExamQuery, BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllTakeExamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>> Handle(GetAllTakeExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>();

            try
            {
                var count = await _unitOfWork.TakeExam.CountAsync(TB.TakeExam);
                var TakeExams = await _unitOfWork.TakeExam.GetAllTakeExams(SP.uspTakeExamList, request);

                if (TakeExams is not null)
                {
                    response.IsSucess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.data = TakeExams;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}

