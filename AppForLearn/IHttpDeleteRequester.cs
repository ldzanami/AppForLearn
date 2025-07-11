namespace AppForLearn
{
    public interface IHttpDeleteRequester
    {
        Task<IActionResult> DeleteAll();
        Task<IActionResult> DeleteArrayToId([FromQuery] int[] ids);
        Task<IActionResult> DeleteRangeToId([FromQuery] int startId, [FromQuery] int endId);
        Task<IActionResult> DeleteToId([FromQuery] int Id);
    }
}
