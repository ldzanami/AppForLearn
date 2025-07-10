
namespace AppForLearn
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetRequestController : ControllerBase
    {
        public required ApplicationContext _appContext = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_appContext.SelectAllFromDataBase());
        }

        [HttpGet("id")]
        public IActionResult GetToId([FromQuery] int id)
        {
            return Ok(_appContext.SelectIdFromDatabase(id));
        }

        [HttpGet("rangeId")]
        public IActionResult GetRangeToId([FromQuery] int startId, [FromQuery] int endId, [FromQuery] bool isDesc)
        {
            return isDesc? Ok(_appContext.SelectRangeToIdDescFromDatabase(startId, endId)) : Ok(_appContext.SelectRangeToIdFromDatabase(startId, endId));
        }

        [HttpGet("sortedToId")]
        public IActionResult GetSortedToId([FromQuery] bool isDesc)
        {
            return isDesc ? Ok(_appContext.SelectAllSortedToIdDescFromDatabase()) : Ok(_appContext.SelectAllSortedToIdFromDatabase());
        }

        [HttpGet("Name")]
        public IActionResult GetToName([FromQuery] string name)
        {
            return Ok(_appContext.SelectNameFromDatabase(name));
        }

        [HttpGet("sortedToName")]
        public IActionResult GetSortedToName([FromQuery] bool isDesc)
        {
            return isDesc ? Ok(_appContext.SelectAllSortedToNameDescFromDatabase()) : Ok(_appContext.SelectAllSortedToNameFromDatabase());
        }

        [HttpGet("cost")]
        public IActionResult GetToCost([FromQuery] float cost)
        {
            return Ok(_appContext.SelectCostFromDatabase(cost));
        }

        [HttpGet("rangeCost")]
        public IActionResult GerRangeToId([FromQuery] float startCost, [FromQuery] float endCost, [FromQuery] bool isDesc)
        {
            return isDesc ? Ok(_appContext.SelectRangeToCostDescFromDatabase(startCost, endCost)) : Ok(_appContext.SelectRangeToCostFromDatabase(startCost, endCost));
        }

        [HttpGet("sortedToCost")]
        public IActionResult GetSortedToCost([FromQuery] bool isDesc)
        {
            return isDesc ? Ok(_appContext.SelectAllSortedToCostDescFromDatabase()) : Ok(_appContext.SelectAllSortedToCostFromDatabase());
        }
    }
}
