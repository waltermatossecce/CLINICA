using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using Entidad =CLINICA.Domain.Entities;
using CLINICA.Utilities.Constantes;
using MediatR;
using CLINICA.Utilities.HelperExtensions;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.CreateCommand
{
    public class CreateExamenHandler : IRequestHandler<CreateExamenCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExamenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateExamenCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                
                var examen = _mapper.Map<Entidad.Examen>(request);

                var parameters = examen.GetPropertyWithValues();

                response.data = await _unitOfWork.Exams.ExecAsync(SP.uspExamRegister,parameters);
                    
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
