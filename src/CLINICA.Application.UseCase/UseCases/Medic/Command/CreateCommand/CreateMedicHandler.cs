using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using Entidad = CLINICA.Domain.Entities;
using MediatR;
using CLINICA.Utilities.HelperExtensions;
using CLINICA.Utilities.Constantes;

namespace CLINICA.Application.UseCase.UseCases.Medic.Command.CreateCommand
{
    public class CreateMedicHandler : IRequestHandler<CreateMedicCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var medicos = _mapper.Map<Entidad.Medic>(request);
                var parameters = medicos.GetPropertyWithValues();
                response.data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicRegister, parameters);

                if (response.data)
                {
                    response.IsSucess = true;
                    response.Message = GlobalMessage.MESSAGE_SAVE;
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
