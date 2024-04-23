using AutoMapper;
using CLINICA.Application.Dtos.TakeExam.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Query.GetByIdQuery
{
    public class GetTakeExamByIdHandler : IRequestHandler<GetTakeExamByIdQuery, BaseResponse<GetTakeExamByIdResponseDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTakeExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetTakeExamByIdResponseDto>> Handle(GetTakeExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetTakeExamByIdResponseDto>();

            try
            {
                var takeExam = await _unitOfWork.TakeExam.GetTakeExamById(request.TakeExamById);

                takeExam.TakeExamDetails = await 
                    _unitOfWork.TakeExam.GetTakeExamDetailByTakeExamId(request.TakeExamById);
                
                response.IsSucess = true;
                response.data = _mapper.Map<GetTakeExamByIdResponseDto>(takeExam);
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
