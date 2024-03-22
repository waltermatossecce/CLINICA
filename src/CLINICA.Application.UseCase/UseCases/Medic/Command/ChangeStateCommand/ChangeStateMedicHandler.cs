using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Command.ChangeStateCommand
{
    public class ChangeStateMedicHandler : IRequestHandler<ChangeStateMedicCommand, BaseResponse<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public ChangeStateMedicHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateMedicCommand request, CancellationToken cancellationToken)
        {
           var response = new BaseResponse<bool>();

            try
            {
                response.data = await _unitOfWork.Medic.ExecAsync(SP.uspChangeStateMedic,request);

                if (response.data)
                {
                    response.IsSucess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE_STATE;
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
