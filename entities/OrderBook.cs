using System.ComponentModel.DataAnnotations;
namespace _EF_Exam_Project_.entities
{
    public class OrderBook : BaseEntities
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int ID_Book { get; set; }
        [Required]
        public int ID_Order { get; set; }
        [Required]
        public int ID_User { get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }
        [Required]
        public int ID_Author { get; set; }
        [Required]
        public int ID_Category { get; set; }
    }
}