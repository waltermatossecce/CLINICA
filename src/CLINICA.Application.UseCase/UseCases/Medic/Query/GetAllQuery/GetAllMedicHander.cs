using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Query.GetAllQuery
{
    public class GetAllMedicHander : IRequestHandler<GetAllMedicQuery, BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllMedicHander(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>> Handle(GetAllMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>();

            try
            {
                var count = await _unitOfWork.Medic.CountAsync(TB.Medics);
                var medicos = await _unitOfWork.Medic.GetMedicAllAsync(SP.uspMedicList,request);

                if(medicos is not null)
                {
                    response.IsSucess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.data = medicos;
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
