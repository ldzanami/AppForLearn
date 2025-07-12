using System.ComponentModel.DataAnnotations;

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
            var result = await databaseDeleteQuerier.DeleteAll();
            return result? NoContent() : NotFound();
        }

        [HttpDelete("arrayToId")]
        public async Task<IActionResult> DeleteArrayToId([FromQuery] int[] ids)
        {
            var result = await databaseDeleteQuerier.DeleteArrayToId(ids);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("rangeToId")]
        public async Task<IActionResult> DeleteRangeToId(
            [FromQuery]
            [Range(1, int.MaxValue, ErrorMessage = "Id Must be positive")]
            int startId,
            [FromQuery]
            [Range(1, int.MaxValue, ErrorMessage = "Id Must be positive")]
            int endId)
        {
            if(endId < startId) return BadRequest();
            var result = await databaseDeleteQuerier.DeleteRangeToId(startId, endId);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("toId")]
        public async Task<IActionResult> DeleteToId([FromQuery] int id)
        {
            var result = await databaseDeleteQuerier.DeleteToId(id);
            return result ? NoContent() : NotFound();
        }
    }
}
