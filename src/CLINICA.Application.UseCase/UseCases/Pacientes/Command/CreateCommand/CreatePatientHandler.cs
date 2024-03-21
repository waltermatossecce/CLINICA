using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Domain.Entities;
using CLINICA.Utilities.Constantes;
using CLINICA.Utilities.HelperExtensions;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Pacientes.Command.CreateCommand
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<bool>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseResponse<bool>();

            try
            {
              var pacientes = _mapper.Map<Patient>(request);
              var parameters = pacientes.GetPropertyWithValues();
              response.data = await _unitOfWork.Patients.ExecAsync(SP.uspPatientRegister,parameters);

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
