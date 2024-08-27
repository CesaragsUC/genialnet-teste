using Application.Handlers.Commands.Products;
using FluentValidation;

namespace Application.Handlers.Validators;

public class UpdateSupplierProductCommandValidator : AbstractValidator<UpdateSupplierProductCommand>
{
    public UpdateSupplierProductCommandValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("{PropertyName} é obrigatorio");
        RuleFor(x => x.Price).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
    }

}