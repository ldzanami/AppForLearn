
namespace AppForLearn
{
    /// <summary>
    /// Product it`s a class из которого создаётся таблица в БД
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Products id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Products name
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Products description
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Products cost
        /// </summary>
        public double Cost { get; set; }
    }
}
