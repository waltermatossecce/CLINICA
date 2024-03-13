using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Domain.Entities;
using MediatR;
using Entity = CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        //private readonly IAnalysisRepository _analysisRepository;
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAnalysisHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = new { analysis.Name };
                response.data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisRegister", parameters);

                if (response.data)
                {
                    response.IsSucess = true;
                    response.Message = "Se registro correctamente.";
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
