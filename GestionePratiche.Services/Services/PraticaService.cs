﻿using AutoMapper;
using FluentValidation;
using GestionePratiche.Dto.Pratiche;
using GestionePratiche.Persistence.Model;
using GestionePratiche.Persistence.Repositories;

namespace GestionePratiche.Services.Services;
public class PraticaService : IPraticaService
{
    private readonly IMapper _mapper;
    private readonly IValidator<CreaPraticaRequest> _validator;
    private readonly IRepository<Pratica> _praticaRepository;

    public PraticaService(IMapper mapper, IValidator<CreaPraticaRequest> validator, IRepository<Pratica> praticaRepository)
    {
        _mapper = mapper;
        _validator = validator;
        _praticaRepository = praticaRepository;
    }

    public async Task<CreaPraticaResponse> CreatePratica(CreaPraticaRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request);
        Pratica pratica = _mapper.Map<Pratica>(request);

        var idPratica = await _praticaRepository.Create(pratica, cancellationToken);

        return _mapper.Map<CreaPraticaResponse>(idPratica);
    }
}
