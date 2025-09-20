using System.ComponentModel.DataAnnotations;
namespace _EF_Exam_Project_.entities
{
    public class User : BaseEntities
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passsword { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}