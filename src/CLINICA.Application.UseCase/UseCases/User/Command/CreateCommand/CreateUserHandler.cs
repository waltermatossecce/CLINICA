using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;
using Entidad = CLINICA.Domain.Entities;
using BC = BCrypt.Net.BCrypt;
using CLINICA.Utilities.HelperExtensions;
using CLINICA.Utilities.Constantes;

namespace CLINICA.Application.UseCase.UseCases.User.Command.CreateCommand
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                //caso de uso mapear nuestro command de mi entidad
                var user = _mapper.Map<Entidad.User>(request);
                //encriptar el password
                user.Password = BC.HashPassword(user.Password);
                //asignamos los valores
                var parameters = user.GetPropertyWithValues();

                response.data = await _unitOfWork.User.ExecAsync(SP.uspUserRegister, parameters);

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
