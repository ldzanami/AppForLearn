
namespace AppForLearn
{
    /// <summary>
    /// Контроллер GET запросов
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GetRequestController : ControllerBase
    {
        /// <summary>
        /// Поле, которое содержит ссылку на объект контекста
        /// </summary>
        public required ApplicationContext _appContext = new();

        /// <summary>
        /// Возвращает всё из таблицы Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _appContext.SelectAllFromDataBase();
            return result.Count > 0? Ok(result) : NoContent();
        }
        /// <summary>
        /// Возвращает товар по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public IActionResult GetToId([FromQuery] int id)
        {
            var result = _appContext.SelectIdFromDatabase(id);
            return result.Count > 0? Ok(result) : NoContent();
        }

        /// <summary>
        /// возвращает товары с startId включительно по endId включительно.
        /// Если isDesc == true, то в обратном порядке
        /// </summary>
        /// <param name="startId"></param>
        /// <param name="endId"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        [HttpGet("rangeId")]
        public IActionResult GetRangeToId([FromQuery] int startId, [FromQuery] int endId, [FromQuery] bool isDesc)
        {
            var result = isDesc ? _appContext.SelectRangeToIdDescFromDatabase(startId, endId) : _appContext.SelectRangeToIdFromDatabase(startId, endId);
            return result.Count > 0? Ok(result) : NoContent();
        }

        /// <summary>
        /// Возвращает сортированные данные таблицы Products по id
        /// isDesc == true => обратный порядок
        /// </summary>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        [HttpGet("sortedToId")]
        public IActionResult GetSortedToId([FromQuery] bool isDesc)
        {
            var result = isDesc ? _appContext.SelectAllSortedToIdDescFromDatabase() : _appContext.SelectAllSortedToIdFromDatabase();
            return result.Count > 0 ? Ok(result) : NoContent();
        }

        /// <summary>
        /// Возвращает продукт по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Name")]
        public IActionResult GetToName([FromQuery] string name)
        {
            var result = _appContext.SelectNameFromDatabase(name);
            return result.Count > 0? Ok(result) : NoContent();
        }

        /// <summary>
        /// Сортированный по имени список
        /// </summary>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        [HttpGet("sortedToName")]
        public IActionResult GetSortedToName([FromQuery] bool isDesc)
        {
            var result = isDesc ? _appContext.SelectAllSortedToNameDescFromDatabase() : _appContext.SelectAllSortedToNameFromDatabase();
            return result.Count > 0? Ok(result) : NoContent();
        }

        /// <summary>
        /// Товар с такой ценой
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        [HttpGet("cost")]
        public IActionResult GetToCost([FromQuery] float cost)
        {
            var result = _appContext.SelectCostFromDatabase(cost);
            return result.Count > 0 ? Ok(result) : NoContent();
        }

        /// <summary>
        /// Товары со startCost включительно по endCost включительно
        /// </summary>
        /// <param name="startCost"></param>
        /// <param name="endCost"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        [HttpGet("rangeCost")]
        public IActionResult GerRangeToId([FromQuery] float startCost, [FromQuery] float endCost, [FromQuery] bool isDesc)
        {
            var result = isDesc ? _appContext.SelectRangeToCostDescFromDatabase(startCost, endCost) : _appContext.SelectRangeToCostFromDatabase(startCost, endCost);
            return result.Count > 0? Ok(result) : NoContent();
        }

        /// <summary>
        /// Список товаров, сотрированный по цене
        /// </summary>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        [HttpGet("sortedToCost")]
        public IActionResult GetSortedToCost([FromQuery] bool isDesc)
        {
            var result = isDesc ? _appContext.SelectAllSortedToCostDescFromDatabase() : _appContext.SelectAllSortedToCostFromDatabase();
            return result.Count > 0? Ok(result) : NoContent();
        }
    }
}
