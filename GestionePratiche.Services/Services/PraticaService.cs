using AutoMapper;
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

    public async Task<CreaPraticaResponse> CreatePraticaAsync(CreaPraticaRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request);
        Pratica pratica = _mapper.Map<Pratica>(request);

        Guid idPratica = await _praticaRepository.CreateAsync(pratica, cancellationToken);

        return new CreaPraticaResponse()
        {
            IdPratica = idPratica,
        };
    }
}
