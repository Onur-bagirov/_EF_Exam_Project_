using System.ComponentModel.DataAnnotations;
namespace _EF_Exam_Project_.entities
{
    public class User : BaseEntities
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(200)]
        public string Username { get; set; }
        [Required]
        [MaxLength(500)]
        public string Email { get; set; }
        [Required]
        [MaxLength(500)]
        public string Passsword { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}