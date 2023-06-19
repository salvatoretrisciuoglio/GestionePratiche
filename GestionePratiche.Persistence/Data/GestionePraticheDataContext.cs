using GestionePratiche.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionePratiche.Persistence.Data;
public class GestionePraticheDataContext : DbContext
{
    public DbSet<Pratica> Pratiche { get; set; }

    public GestionePraticheDataContext(DbContextOptions<GestionePraticheDataContext> options) : base(options)
    {
    }
}
