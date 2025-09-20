namespace _EF_Exam_Project_.entities
{
    public class OrderBook : BaseEntities
    {
        public decimal Price { get; set; }
        public int ID_Book { get; set; }
        public int ID_Order { get; set; }
        public int ID_User { get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }
        public int ID_Author { get; set; }
        public int ID_Category { get; set; }
    }
}