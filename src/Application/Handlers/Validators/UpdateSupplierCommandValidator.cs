using Application.Handlers.Commands.Supplier;
using Domain.ValueObjects;
using FluentValidation;

namespace Application.Handlers.Validators;

public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
{
    public UpdateSupplierCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.CNPJ).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.Address).NotNull().WithMessage("Endereco é obrigatorio");
    }
}