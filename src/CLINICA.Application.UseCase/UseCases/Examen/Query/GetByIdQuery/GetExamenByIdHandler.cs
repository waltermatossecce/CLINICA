using AutoMapper;
using CLINICA.Application.Dtos.Analysis.Response;
using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using CLINICA.Utilities.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.UseCase.UseCases.Examen.Query.GetByIdQuery
{
    public class GetExamenByIdHandler : IRequestHandler<GetExamenByIdQuery, BaseResponse<GetExamenByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExamenByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetExamenByIdResponseDto>> Handle(GetExamenByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetExamenByIdResponseDto>();

            try
            {
                var examen = await _unitOfWork.Exams.GetByIdAsync(SP.uspExamenById, request);

                if(examen == null)
                {
                    response.IsSucess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                response.IsSucess = true;
                response.data = _mapper.Map<GetExamenByIdResponseDto>(examen);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;               
            }
            return response;
        }
    }
}
