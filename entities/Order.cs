using System.ComponentModel.DataAnnotations;
namespace _EF_Exam_Project_.entities
{
    public class Order : BaseEntities
    {
        [Required]
        public decimal Price { get; set; }
        public DateTime OrderDateTime { get; set; } = DateTime.Now;
        [Required]
        public int ID_User { get; set; }
        [Required]
        public int ID_Book { get; set; }
        public User User { get; set; }
        public ICollection<OrderBook> OrderBook { get; set; }
    }
}