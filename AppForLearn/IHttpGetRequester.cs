namespace AppForLearn
{
    public interface IHttpGetRequester
    {
        IActionResult GetRangeToCost([FromQuery] float startCost, [FromQuery] float endCost, [FromQuery] bool isDesc);
        IActionResult GetArrayToId([FromQuery] int[] ids);
        IActionResult GetAll();
        IActionResult GetRangeToId([FromQuery] int startId, [FromQuery] int endId, [FromQuery] bool isDesc);
        IActionResult GetSortedToCost([FromQuery] bool isDesc);
        IActionResult GetSortedToId([FromQuery] bool isDesc);
        IActionResult GetSortedToName([FromQuery] bool isDesc);
        IActionResult GetToCost([FromQuery] float cost);
        IActionResult GetToId([FromQuery] int id);
        IActionResult GetToName([FromQuery] string name);
    }
}