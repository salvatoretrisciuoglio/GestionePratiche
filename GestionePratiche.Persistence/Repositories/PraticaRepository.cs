using GestionePratiche.Persistence.Data;
using GestionePratiche.Persistence.Model;

namespace GestionePratiche.Persistence.Repositories;
public class PraticaRepository : Repository<Pratica, GestionePraticheDataContext>
{
    public PraticaRepository(GestionePraticheDataContext dbContext) : base(dbContext)
    {
    }
}
