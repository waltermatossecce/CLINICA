using AutoMapper;
using CLINICA.Application.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;
using Entity = CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.DeleteCommands
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {

        private readonly IAnalysisRepository _analysisRepository;

        public DeleteAnalysisHandler(IAnalysisRepository analysisRepository)
        {
            _analysisRepository = analysisRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.data = await _analysisRepository.AnalysisDelete(request.AnalysisId);

                if (response.data)
                {
                    response.IsSucess = true;
                    response.Message = "Se elimino correctamente";
                }

            }catch (Exception ex)
            {
                response.Message =ex.Message;
            }
            return response;

        }
    }
}
