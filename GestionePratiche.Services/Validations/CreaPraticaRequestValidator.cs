using FluentValidation;
using GestionePratiche.Dto.Pratiche;

namespace GestionePratiche.Services.Validations;
public class CreaPraticaRequestValidator : AbstractValidator<CreaPraticaRequest>
{
    public CreaPraticaRequestValidator()
    {
        RuleFor(x => x.CodiceFiscale)
        .NotNull()
        .NotEmpty()
        .FiscalCode()
        .WithMessage(ValidationMessages.FiscalCodeNotValid);
    }
}
