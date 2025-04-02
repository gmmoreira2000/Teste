using AutoMapper;
using Business.ViewModels;
using Domain;

namespace Business.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}
