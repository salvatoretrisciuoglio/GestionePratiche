using FluentValidation;
using GestionePratiche.Dto.Pratiche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePratiche.Services.Validations;
public class CreaPraticaRequestValidator : AbstractValidator<CreaPraticaRequest>
{
    public CreaPraticaRequestValidator()
    {
        RuleFor(x => x.CodiceFiscale)
        .NotNull()
        .NotEmpty()
        .FiscalCode();

    }
}
