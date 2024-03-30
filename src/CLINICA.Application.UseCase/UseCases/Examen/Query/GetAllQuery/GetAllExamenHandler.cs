using AutoMapper;
using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Query.GetAllQuery
{
    public class GetAllExamenHandler : IRequestHandler<GetAllExamenQuery,BasePaginationResponse<IEnumerable<GetAllExamenResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
   

        public GetAllExamenHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllExamenResponseDto>>> Handle(GetAllExamenQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllExamenResponseDto>>();

            try
            {
                var count = await _unitOfWork.Exams.CountAsync(TB.Exams);
                var examen = await _unitOfWork.Exams.GetAllExams(SP.uspExamList,request);

                if (examen is not null)
                { 
                    response.IsSucess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.data = examen;
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
