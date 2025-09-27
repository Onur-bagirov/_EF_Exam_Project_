using System.ComponentModel.DataAnnotations;
namespace _EF_Exam_Project_.entities
{
    public class Book : BaseEntities
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int ID_Author { get; set; }
        [Required]
        public int ID_Category { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderBook> OrderBook { get; set; }
    }
}
