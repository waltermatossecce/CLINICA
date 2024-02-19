using AutoMapper;
using CLINICA.Application.Dtos.Analysis.Response;
using CLINICA.Application.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Query.GetByIdQuery
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public AnalysisByIdHandler(IAnalysisRepository analysisRepository = null, IMapper mapper = null)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();

            try
            {

                var analysis = await _analysisRepository.AnalysisById(request.AnalysisId); 
                
                if(analysis is null)
                {
                    response.IsSucess = false;
                    response.Message = "No se encontro registros";
                    return response;
                }
                response.IsSucess = true;
                response.data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                response.Message = "Consulta Exitosa";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
