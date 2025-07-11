namespace AppForLearn
{
    public interface IHttpPostRequester<T>
    {
        Task<IActionResult> AddItem([FromBody] T item);
        Task<IActionResult> AddItems([FromBody] T[] items);
    }
}
