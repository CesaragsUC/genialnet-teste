using Application.Handlers.Commands.Suppliers;
using Domain.ValueObjects;
using FluentValidation;

namespace Application.Handlers.Validators;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.CNPJ).NotEmpty().WithMessage("{PropertyName}  é obrigatorio").Must(IsValidCnpj);
        RuleFor(x => x.Phone).NotEmpty().WithMessage("{PropertyName}  é obrigatorio");
        RuleFor(x => x.Address).NotNull().WithMessage("Endereco é obrigatorio");
    }
    protected static bool IsValidCnpj(string cnpj)
    {
        return CnpjValidator.Validate(cnpj);
    }
}
