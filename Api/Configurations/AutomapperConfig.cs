using Api.ViewModel;
using AutoMapper;
using Domain;

namespace Api.Configurations
{
    public class AutomapperConfig : Profile
    { 
        public AutomapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}
