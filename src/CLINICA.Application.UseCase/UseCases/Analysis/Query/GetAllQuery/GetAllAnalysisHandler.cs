using AutoMapper;
using CLINICA.Application.Dtos.Analysis.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Query.GetAllQuery
{
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        //private readonly IAnalysisRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>();

            try
            {

                var analysis = await _unitOfWork.Analysis.GetAllAsync("uspAnalysisList");

                if(analysis is not null)
                {
                    response.IsSucess = true;
                    response.data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
                    response.Message = "Consulta Exitosa!";
                }

            }catch (Exception ex)
            {
               response.Message = ex.Message;
            }
            return response;
        }
    }
}
