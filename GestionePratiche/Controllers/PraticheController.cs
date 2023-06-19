using GestionePratiche.Dto.Pratiche;
using Microsoft.AspNetCore.Mvc;

namespace GestionePratiche.Controllers;
[ApiController]
[Route("api/gestionepratiche/v{version:apiVersion}")]
[ApiVersion("1")]
public class PraticheController : ControllerBase
{
    private readonly IPraticaService _praticaService;
    private readonly ILogger<PraticheController> _logger;


    public PraticheController(ILogger<PraticheController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "creaPratica")]
    public Task<ActionResult<CreaPraticaResponse>> CreaPratica(CreaPraticaRequest request, CancellationToken cancellationToken)
    {
       _praticaService.CreaPratica(request,cancellationToken);
    }
}
