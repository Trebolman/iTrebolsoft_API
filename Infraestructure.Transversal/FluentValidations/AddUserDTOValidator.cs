using Application.DTOs;
using FluentValidation;

namespace Infraestructure.Transversal.FluentValidations
{
    public class AddUserDTOValidator:AbstractValidator<addUserDTO>
    {
        public AddUserDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).Length(5, 30);
            RuleFor(x => x.UserEmail).NotEmpty();
            RuleFor(x => x.UserEmail).Length(5, 100);
            RuleFor(x => x.UserEmail).EmailAddress();
            RuleFor(x => x.UserRole).NotEmpty();
            RuleFor(x => x.UserPhone).Length(9);
            RuleFor(x => x.UserAddress).Length(5, 30);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(5, 20);
        }
    }
}
