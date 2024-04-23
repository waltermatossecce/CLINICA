using AutoMapper;
using CLINICA.Application.Dtos.Patients.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Utilities.Constantes;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Pacientes.Query.GetAllQuery
{
    public class GetAllPatientHandler : IRequestHandler<GetAllPatientQuery, BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<BaseResponse<IEnumerable<GetAllPatientResponseDto>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllPatientResponseDto>>();

            try
            {
//var count = await _unitOfWork.Patients.CountAsync(TB.Pacientes);
                var pacientes = await _unitOfWork.Patients.GetAllPatient(SP.uspPatientList);

                if (pacientes is not null)
                {
                    response.IsSucess = true;
                    response.data = pacientes;
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
