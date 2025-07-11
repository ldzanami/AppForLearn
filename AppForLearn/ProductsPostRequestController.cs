
namespace AppForLearn
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsPostRequestController : ControllerBase, IHttpPostRequester<Product>
    {
        public required IDatabasePostQuerier<Product> databasePostQuerier = new ProductsPostQuerier();

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await databasePostQuerier.AddItem(product);
            return CreatedAtAction(actionName: "GetToId", controllerName: "ProductsGetRequest", routeValues: new { product.Id }, value: product);
        }

        [HttpPost("array")]
        public async Task<IActionResult> AddItems([FromBody] Product[] products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await databasePostQuerier.AddItems(products);
            return Ok();
        }
    }
}
