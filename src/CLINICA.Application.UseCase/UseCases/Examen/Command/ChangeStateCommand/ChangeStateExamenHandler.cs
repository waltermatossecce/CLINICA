using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using Entidad = CLINICA.Domain.Entities;
using CLINICA.Utilities.Constantes;
using MediatR;
using CLINICA.Utilities.HelperExtensions;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.ChangeStateCommand
{
    public class ChangeStateExamenHandler : IRequestHandler<ChangeStateExamenCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateExamenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<bool>> Handle(ChangeStateExamenCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {

                var examen = _mapper.Map<Entidad.Examen>(request);
                var parameter = examen.GetPropertyWithValues();
                response.data = await _unitOfWork.Exams.ExecAsync(SP.uspExamenChangeState, request);

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
