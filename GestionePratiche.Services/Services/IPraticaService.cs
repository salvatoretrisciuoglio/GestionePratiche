using GestionePratiche.Dto.Pratiche;

namespace GestionePratiche.Services.Services;
public interface IPraticaService
{
    Task<CreaPraticaResponse> CreatePraticaAsync(CreaPraticaRequest request, CancellationToken cancellationToken);
}