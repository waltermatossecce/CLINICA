using AutoMapper;
using CLINICA.Application.Dtos.Patients.Response;
using CLINICA.Application.UseCase.UseCases.Pacientes.Command.CreateCommand;
using CLINICA.Application.UseCase.UseCases.Pacientes.Command.DeleteCommand;
using CLINICA.Application.UseCase.UseCases.Pacientes.Command.UpdateCommand;
using CLINICA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.UseCase.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<GetPatientByIdResponseDto, Patient>()
                .ReverseMap();

            CreateMap<CreatePatientCommand, Patient>();

            CreateMap<UpdatePatientCommand, Patient>();

            CreateMap<DeletePatientCommand,Patient>();

            CreateMap<UpdatePatientCommand, Patient>();
        }
    }
}
