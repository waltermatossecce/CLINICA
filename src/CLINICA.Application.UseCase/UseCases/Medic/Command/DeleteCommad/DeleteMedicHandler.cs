using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Command.DeleteCommad
{
    public class DeleteMedicHandler : IRequestHandler<DeleteMedicCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMedicHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteMedicCommand request, CancellationToken cancellationToken)
        {
           var response = new BaseResponse<bool>();

            try
            {
                response.data = await _unitOfWork.Patients.ExecAsync(SP.uspMedicRemove,request);

                if(response.data)
                {
                    response.IsSucess = true;
                    response.Message = GlobalMessage.MESSAGE_DELETE;
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
