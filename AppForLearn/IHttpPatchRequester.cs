using Microsoft.AspNetCore.JsonPatch;

namespace AppForLearn
{
    public interface IHttpPatchRequester<T>
    {
        Task<IActionResult> PatchOne([FromBody] T item);
        Task<IActionResult> PatchArray([FromBody] T[] items);
        Task<HttpResultsEnum> TryPatchItem(T patchItem);
    }
}
