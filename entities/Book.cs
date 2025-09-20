namespace _EF_Exam_Project_.entities
{
    public class Book : BaseEntities
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int ID_Author { get; set; }
        public int ID_Category { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderBook> OrderBook { get; set; }
    }
}
