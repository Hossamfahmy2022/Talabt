using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Talabt.Api.Dtos;
using Talabt.Core.Entities;

namespace Talabt.Api.Mapping
{
    public class PictureUrlReslover(IConfiguration configuration) : IValueResolver<Product, ProductToReturnDto, string>
    {
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                {
                    return string.Concat(configuration.GetSection("BaseUrl"), source.PictureUrl);
                }
            }
            return string.Empty;
        }
    }
}