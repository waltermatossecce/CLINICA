using AutoMapper;
using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Query.GetByIdQuery
{
    public class GetMedicByIdCommand : IRequestHandler<GetMedicByIdQuery, BaseResponse<GetMedicByIdResponseDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMedicByIdCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetMedicByIdResponseDto>> Handle(GetMedicByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetMedicByIdResponseDto>();

            try
            {
                var medicos = await _unitOfWork.Medic.GetByIdAsync(SP.uspMedicById, request);

                if (medicos is null)
                { 
                    response.IsSucess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                response.IsSucess = true;
                response.data = _mapper.Map<GetMedicByIdResponseDto>(medicos);
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
