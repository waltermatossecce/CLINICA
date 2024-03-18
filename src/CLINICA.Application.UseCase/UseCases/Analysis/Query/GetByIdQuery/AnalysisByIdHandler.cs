using AutoMapper;
using CLINICA.Application.Dtos.Analysis.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Query.GetByIdQuery
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
      //  private readonly IAnalysisRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnalysisByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();

            try
            {

                var analysis = await _unitOfWork.Analysis.GetByIdAsync(SP.uspAnalysisById, request); 
                
                if(analysis is null)
                {
                    response.IsSucess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                response.IsSucess = true;
                response.data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                response.Message = GlobalMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
