using AutoMapper;

using LabFashion.Models;
using LabFashion.Models.ViewModels;

namespace LabFashion.Mappers.Profiles
{
    public class PostColecaoProfile : Profile
    {
        public PostColecaoProfile()
        {
            CreateMap<PostColecao, Colecao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Modelos, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
