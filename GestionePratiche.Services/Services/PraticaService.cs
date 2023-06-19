using AutoMapper;
using FluentValidation;
using GestionePratiche.Dto.Pratiche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionePratiche.Services.Services;
public class PraticaService
{
    private readonly IMapper _mapper;
    private readonly IValidator<CreaPraticaRequest> _validator;
    public PraticaService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<CreaPraticaResponse> CreatePratica(CreaPraticaRequest request)
    {
        _validator.ValidateAndThrowAsync(request);


        return Task.FromResult(new CreaPraticaResponse());
    }
}
