using Talabt.Core.Entities;

namespace Talabt.Api.Dtos
{
    public record ProductToReturnDto
        (
         string Name,
         string Description,
         decimal Price,
         string PictureUrl,
         int BrandId,
         int CatergoryId,
         string Brand,
         string catergory
        );

}
