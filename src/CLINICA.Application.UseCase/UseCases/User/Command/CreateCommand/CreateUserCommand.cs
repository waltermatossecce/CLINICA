using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.User.Command.CreateCommand
{
    public class CreateUserCommand : IRequest<BaseResponse<bool>>
    {

        public string? FirstName { get; set; }
        public string? Latname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
