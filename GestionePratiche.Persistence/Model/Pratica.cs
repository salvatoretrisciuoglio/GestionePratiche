using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionePratiche.Persistence.Model;
public class Pratica : IEntityBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Cognome { get; set; }

    public string CodiceFiscale { get; set; }

    public DateTime DataDiNascita { get; set; }

    [NotMapped]
    public IFormFile AllegatoPratica { get; set; }
}
