using AutoMapper;
using CLINICA.Application.UseCase.UseCases.User.Command.CreateCommand;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.UseCase.Mappings
{
    public class UserMappingProfile :Profile
    {
        public UserMappingProfile()
        {

            CreateMap<CreateUserCommand, User>();
        }
    }
}
