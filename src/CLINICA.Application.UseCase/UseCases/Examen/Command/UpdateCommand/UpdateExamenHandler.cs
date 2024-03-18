using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using Entidad = CLINICA.Domain.Entities;
using MediatR;
using CLINICA.Utilities.HelperExtensions;
using CLINICA.Utilities.Constantes;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.UpdateCommand
{
    internal class UpdateExamenHandler : IRequestHandler<UpdateExamenCommand, BaseResponse<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateExamenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateExamenCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var examen = _mapper.Map<Entidad.Examen>(request);

                var parameters = examen.GetPropertyWithValues();
                
                response.data = await _unitOfWork.Exams.ExecAsync(SP.uspExamenUpdate, parameters);

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
