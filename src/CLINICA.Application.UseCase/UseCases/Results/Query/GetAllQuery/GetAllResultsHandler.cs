using AutoMapper;
using CLINICA.Application.Dtos.Results.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Results.Query.GetAllQuery
{
    public class GetAllResultsHandler : IRequestHandler<GetAllResultsQuery, BasePaginationResponse<IEnumerable<GetAllResultsResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllResultsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllResultsResponseDto>>> Handle(GetAllResultsQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllResultsResponseDto>>();

            try
            {
                var count = await _unitOfWork.Results.CountAsync(TB.Resultados);

                var result = await _unitOfWork.Results.GetAllResults(SP.uspResultList,request);

                if(result is not null)
                {
                    response.IsSucess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.data = result;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
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
