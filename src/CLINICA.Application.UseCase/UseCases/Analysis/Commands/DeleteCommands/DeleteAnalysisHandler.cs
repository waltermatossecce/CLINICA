using AutoMapper;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;
using Entity = CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.DeleteCommands
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {

        //private readonly IAnalysisRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DeleteAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var parameter = new { request.AnalysisId };
                response.data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisRemove", parameter);

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
