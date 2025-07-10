
namespace AppForLearn
{
    public interface IHttpGetableAsync
    {
        [HttpGet]
        Task GetRequestAsync();
    }
}
