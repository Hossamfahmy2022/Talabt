using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabt.Api.Dtos;
using Talabt.Core.Entities;
using Talabt.Core.Reposirties.Contracts;
using Talabt.Core.Specasifcations;
using Talabt.Core.Specasifcations.ProductSpecs;

namespace Talabt.Api.Controllers
{

    public class ProductController(IGenericRepostriy<Product> Productrepostriy
        , IMapper mapper) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var specs = new ProductSpecifications();
            var products = await Productrepostriy.GetAllWithSpecsAsync(specs);

            return Ok(mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var specs = new ProductSpecifications(id);
            var product = await Productrepostriy.GetWithSpecsAsync(specs);
            if (product is null)
                return NotFound();
            var response = mapper.Map<ProductToReturnDto>(product);
            return Ok(response);
        }

    }
}
