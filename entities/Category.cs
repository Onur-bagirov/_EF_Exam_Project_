using System.ComponentModel.DataAnnotations;
namespace _EF_Exam_Project_.entities
{
    public class Category : BaseEntities
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}

