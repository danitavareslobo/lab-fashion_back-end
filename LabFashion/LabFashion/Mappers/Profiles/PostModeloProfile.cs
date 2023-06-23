using AutoMapper;

using LabFashion.Models;
using LabFashion.Models.ViewModels;

namespace LabFashion.Mappers.Profiles
{
    public class PostModeloProfile : Profile
    {
        public PostModeloProfile()
        {
            CreateMap<PostModelo, Modelo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Colecao, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
