using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using Entidad = CLINICA.Domain.Entities;
using MediatR;
using CLINICA.Utilities.HelperExtensions;
using CLINICA.Utilities.Constantes;

namespace CLINICA.Application.UseCase.UseCases.Medic.Command.UpdateCommand
{
    public class UpdateMedicHandler : IRequestHandler<UpdateMedicCommand, BaseResponse<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var medicos = _mapper.Map<Entidad.Medic>(request);
                var paremeters = medicos.GetPropertyWithValues();
                response.data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicUpdate, paremeters);

                if (response.data)
                {
                    response.IsSucess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE;
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
