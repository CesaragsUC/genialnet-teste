using Application.Handlers.Commands.Products;
using FluentValidation;

namespace Application.Handlers.Validators;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty().NotNull().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.Brand).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.Description).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("Preco precisa ser maior que 0");
    }
}
