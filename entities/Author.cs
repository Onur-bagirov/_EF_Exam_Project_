namespace _EF_Exam_Project_.entities
{
    public class Author : BaseEntities
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
