using AutoMapper;
using CLINICA.Application.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;
using Entity = CLINICA.Domain.Entities;


namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public UpdateAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.data = await _analysisRepository.AnalysisEdit(analysis);

                if (response.data)
                {
                    response.IsSucess = true;
                    response.Message = "Se actualizo correctamente.";
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
