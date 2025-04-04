using AutoMapper;
using Business.ViewModels;
using Business.DTOs;
using Domain;

namespace Business.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
            CreateMap<ContatoViewModel, ContatoDTO>().ReverseMap();
            CreateMap<ContatoDTO, Contato>().ReverseMap();
        }
    }
}
