
using System.ComponentModel.DataAnnotations;

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
        [Key]
        public required int Id { get; set; }
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
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost must be positive and bigger than zero")]
        public required double Cost { get; set; }
    }
}
