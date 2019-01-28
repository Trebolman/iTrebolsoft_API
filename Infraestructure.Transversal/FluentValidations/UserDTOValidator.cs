using Application.DTOs;
using FluentValidation;

namespace Infraestructure.Transversal.FluentValidations
{
    public class UserDTOValidator:AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.UserFirstName).NotEmpty();
            RuleFor(x => x.UserLastname).NotEmpty();
            RuleFor(x => x.UserRole).NotEmpty();
            RuleFor(x => x.UserEmail).EmailAddress();
            RuleFor(x => x.UserEmail).NotEmpty();
        }
    }
}
