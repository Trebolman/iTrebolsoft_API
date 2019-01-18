using Application.DTOs;
using FluentValidation;

namespace Infraestructure.Transversal.FluentValidations
{
    public class UserDTOValidator:AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).Length(2, 30);
            RuleFor(x => x.UserEmail).NotEmpty();
            RuleFor(x => x.UserEmail).Length(10, 100);
        }
    }
}
