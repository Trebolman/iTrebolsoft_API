using Application.DTOs;
using FluentValidation;
namespace Infraestructure.Transversal.FluentValidations
{
    public class ProyectoDTOValidator : AbstractValidator<ProyectoDTO>
    {
        //Usa la libreria FluentValidation para validar las entradas
        public ProyectoDTOValidator()
        {
            RuleFor(x => x.ProyTitle).NotEmpty();
            RuleFor(x => x.ProyTitle).Length(2, 30);
            RuleFor(x => x.ProyDesc).NotEmpty();
            RuleFor(x => x.ProyDesc).Length(10, 100);
            RuleFor(x => x.ProyDate).NotEmpty();
            RuleFor(x => x.FkTUserUserId).NotEmpty();
        }
    }
}