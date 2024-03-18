using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.DeleteCommand
{
    public class DeleteExamenHandler : IRequestHandler<DeleteExamenCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExamenHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteExamenCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                
                response.data = await _unitOfWork.Exams.ExecAsync(SP.uspExamenDelete, request);
                
                if (response.data)
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
