using GestionePratiche.Dto.Pratiche;
using GestionePratiche.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionePratiche.Controllers.V1;
[ApiController]
[Route("api/[controller]/v{version:apiVersion}")]
[ApiVersion("1.0")]
public class PraticheController : ControllerBase
{
    private readonly IPraticaService _praticaService;
    private readonly ILogger<PraticheController> _logger;


    public PraticheController(ILogger<PraticheController> logger, IPraticaService praticaService)
    {
        _logger = logger;
        _praticaService = praticaService;
    }

    [HttpPost(Name = "creaPratica")]
    public async Task<ActionResult<CreaPraticaResponse>> CreaPratica([FromForm] CreaPraticaRequest request, CancellationToken cancellationToken)
    {
        CreaPraticaResponse response = await _praticaService.CreatePratica(request, cancellationToken);
        return Ok(response);
    }
}
