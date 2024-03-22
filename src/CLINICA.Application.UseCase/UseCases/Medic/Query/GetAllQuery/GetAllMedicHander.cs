using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Query.GetAllQuery
{
    public class GetAllMedicHander : IRequestHandler<GetAllMedicQuery, BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllMedicHander(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllMedicResponseDto>>> Handle(GetAllMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllMedicResponseDto>>();

            try
            {
                var medicos = await _unitOfWork.Medic.GetMedicAllAsync(SP.uspMedicList);

                if(medicos is not null)
                {
                    response.IsSucess = true;
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
