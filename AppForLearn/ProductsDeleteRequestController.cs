
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AppForLearn
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsDeleteRequestController : ControllerBase, IHttpDeleteRequester
    {
        public IDatabaseDeleteQuerier databaseDeleteQuerier = new ProductsDeleteQuerier();

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAll()
        {
            await databaseDeleteQuerier.DeleteAll();
            return Ok();
        }

        [HttpDelete("arrayToId")]
        public async Task<IActionResult> DeleteArrayToId([FromQuery] int[] ids)
        {
            await databaseDeleteQuerier.DeleteArrayToId(ids);
            return Ok();
        }

        [HttpDelete("rangeToId")]
        public async Task<IActionResult> DeleteRangeToId([FromQuery] int startId, [FromQuery] int endId)
        {
            await databaseDeleteQuerier.DeleteRangeToId(startId, endId);
            return Ok();
        }

        [HttpDelete("toId")]
        public async Task<IActionResult> DeleteToId([FromQuery] int id)
        {
            await databaseDeleteQuerier.DeleteToId(id);
            return Ok();
        }
    }
}
