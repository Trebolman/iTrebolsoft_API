using Application.DTOs;
using FluentValidation;

namespace Infraestructure.Transversal.FluentValidations
{
    public class ProductDTOValidator : AbstractValidator<ProductoDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.ProdName).NotEmpty();
            RuleFor(x => x.ProdName).Length(2, 30);
            RuleFor(x => x.ProdCod).NotEmpty();
            RuleFor(x => x.ProdCod).Length(10, 100);
            RuleFor(x => x.ProdDesc).NotEmpty();
            RuleFor(x => x.ProdPrice).NotEmpty();
            RuleFor(x => x.FkUserUserId).NotEmpty();
        }
    }
}
