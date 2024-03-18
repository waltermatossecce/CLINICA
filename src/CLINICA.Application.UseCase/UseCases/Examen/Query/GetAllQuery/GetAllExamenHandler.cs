using AutoMapper;
using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Query.GetAllQuery
{
    public class GetAllExamenHandler : IRequestHandler<GetAllExamenQuery, BaseResponse<IEnumerable<GetAllExamenResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
   

        public GetAllExamenHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllExamenResponseDto>>> Handle(GetAllExamenQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllExamenResponseDto>>();

            try
            {
                var examen = await _unitOfWork.Exams.GetAllExams(SP.uspExamList);

                if (examen is not null)
                { 
                    response.IsSucess = true;
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
