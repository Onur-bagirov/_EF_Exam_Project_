namespace _EF_Exam_Project_.entities
{
    public class Category : BaseEntities
    {
        public string Name { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}

