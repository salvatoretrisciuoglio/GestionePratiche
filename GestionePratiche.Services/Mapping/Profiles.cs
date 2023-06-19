using AutoMapper;
using GestionePratiche.Dto.Pratiche;
using GestionePratiche.Persistence.Model;

namespace GestionePratiche.Services.Mapping;
public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<CreaPraticaRequest, Pratica>();
    }
}
