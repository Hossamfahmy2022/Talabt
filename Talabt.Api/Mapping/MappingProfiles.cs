using AutoMapper;
using Talabt.Api.Dtos;
using Talabt.Core.Entities;

namespace Talabt.Api.Mapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles(IConfiguration configuration)
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dest => dest.Brand, O => O.MapFrom(s => s.Brand.Name))
                .ForMember(dest => dest.catergory, O => O.MapFrom(s => s.catergory.Name))
               //.ForMember(dest => dest.PictureUrl,
               // O => O.MapFrom(s=> string.Concat(configuration.GetSection("BaseUrl"), s.PictureUrl)));
               .ForMember(dest => dest.PictureUrl, O => O.MapFrom<PictureUrlReslover>());
                }
    }
}
