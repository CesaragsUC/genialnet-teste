using Application.Handlers.Commands.Products;
using FluentValidation;

namespace Application.Handlers.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.Brand).NotEmpty().WithMessage("{PropertyName} é obrigatorio");
        RuleFor(x => x.Description).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
    }
}
