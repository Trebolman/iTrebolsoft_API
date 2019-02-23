using Application.DTOs;
using FluentValidation;

namespace Infraestructure.Transversal.FluentValidations
{
    public class AddUserDTOValidator:AbstractValidator<AddUserDTO>
    {
        public AddUserDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).Length(5, 30);
            RuleFor(x => x.UserEmail).NotEmpty();
            RuleFor(x => x.UserEmail).Length(5, 100);
            RuleFor(x => x.UserEmail).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(5, 20);
        }
    }
}
