using System.ComponentModel.DataAnnotations;
namespace _EF_Exam_Project_.entities
{
    public class Author : BaseEntities
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
