using AutoMapper;

using LabFashion.Models;
using LabFashion.Models.ViewModels;

namespace LabFashion.Mappers.Profiles
{
    public class PutColecaoProfile : Profile
    {
        public PutColecaoProfile()
        {
            CreateMap<PutColecao, Colecao>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Modelos, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
