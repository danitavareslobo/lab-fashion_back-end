using AutoMapper;

using LabFashion.Models;
using LabFashion.Models.ViewModels;

namespace LabFashion.Mappers.Profiles
{
    public class PostUsuarioProfile : Profile
    {
        public PostUsuarioProfile()
        {
            CreateMap<PostUsuario, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Colecao, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
