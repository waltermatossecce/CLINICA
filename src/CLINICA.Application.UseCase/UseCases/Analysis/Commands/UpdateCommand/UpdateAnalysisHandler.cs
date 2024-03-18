using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using CLINICA.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICA.Domain.Entities;


namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        //private readonly IAnalysisRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = analysis.GetPropertyWithValues();
                response.data = await _unitOfWork.Analysis.ExecAsync(SP.uspAnalysisEdit, parameters);

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
