using AutoMapper;
using CLINICA.Application.Dtos.Patients.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.UseCase.UseCases.Pacientes.Query.GetByIdQuery
{
    public class GetPatientHandler : IRequestHandler<GetPatientByIdQuery, BaseResponse<GetPatientByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetPatientByIdResponseDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetPatientByIdResponseDto>();

            try
            {
                var patient = await _unitOfWork.Patients.GetByIdAsync(SP.uspPatientById, request);

                if (patient == null)
                {
                    response.IsSucess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                }
                response.IsSucess = true;
                response.Message = GlobalMessage.MESSAGE_QUERY;
                response.data = _mapper.Map<GetPatientByIdResponseDto>(patient);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
