using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using Entidad = CLINICA.Domain.Entities;
using MediatR;
using CLINICA.Utilities.HelperExtensions;
using CLINICA.Utilities.Constantes;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisHandler : IRequestHandler<ChangeStateAnalysisCommand, BaseResponse<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChangeStateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entidad.Analysis>(request);
                var parameters = analysis.GetPropertyWithValues();
                response.data = await _unitOfWork.Analysis.ExecAsync(SP.uspAnalysisChangeState,parameters);

                if (response.data)
                {
                    response.IsSucess = true;
                    response.Message = "Se actualizo el estadocorrectamente";
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
