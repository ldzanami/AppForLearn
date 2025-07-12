
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace AppForLearn
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsPatchRequestController : ControllerBase, IHttpPatchRequester<Product>
    {
        public required IDatabasePatchQuerier<List<Product>, Product> databasePatchQuerier = new ProductsPatchQuerier();

        public async Task<HttpResultsEnum> TryPatchItem(Product patch)
        {
            var product = await databasePatchQuerier.FindItemFromDB(patch.Id);
            if (product == null) return HttpResultsEnum.NotFound;
            product.Name = patch.Name;
            product.Description = patch.Description;
            product.Cost = patch.Cost;
            if (!ModelState.IsValid) return HttpResultsEnum.BadRequest;
            await databasePatchQuerier.ReplaceItemInDB(product);
            return HttpResultsEnum.NoContent;
        }

        [HttpPatch("array")]
        public async Task<IActionResult> PatchArray([FromBody] Product[] patchProducts)
        {
            for(int i = 0; i < patchProducts.Length; i++)
            {
                var result = await TryPatchItem(patchProducts[i]);
                switch (result)
                {
                    case HttpResultsEnum.NotFound: return NotFound();
                    case HttpResultsEnum.BadRequest: return BadRequest(ModelState);
                }
            }
            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> PatchOne([FromBody] Product patchProduct)
        {
            var result = await TryPatchItem(patchProduct);
            return result switch
            {
                HttpResultsEnum.NotFound => NotFound(),
                HttpResultsEnum.BadRequest => BadRequest(ModelState),
                _ => NoContent()
            };
        }
    }
}
