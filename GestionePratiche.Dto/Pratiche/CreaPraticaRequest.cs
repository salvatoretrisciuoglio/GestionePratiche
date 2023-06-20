using Microsoft.AspNetCore.Http;
namespace GestionePratiche.Dto.Pratiche;
public class CreaPraticaRequest
{
    public string Nome { get; set; }

    public string Cognome { get; set; }

    public string CodiceFiscale { get; set; }

    public DateTime DataDiNascita { get; set; }

    public IFormFile? AllegatoPratica { get; set; }
}
