using System.ComponentModel.DataAnnotations;
namespace _EF_Exam_Project_.entities
{
    public class BaseEntities
    {
        [Key]
        public int ID { get; set; }
        public DateTime Create { get; set; } = DateTime.Now;
        public DateTime Update { get; set; }
        public DateTime Delete { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
