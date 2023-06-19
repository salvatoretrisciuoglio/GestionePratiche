using GestionePratiche.Dto.Pratiche;

namespace GestionePratiche.Services.Services;
public interface IPraticaService
{
    Task<CreaPraticaResponse> CreatePratica(CreaPraticaRequest request, CancellationToken cancellationToken);
}