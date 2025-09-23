namespace _EF_Exam_Project_.entities
{
    public class Order : BaseEntities
    {
        public decimal Price { get; set; }
        public DateTime OrderDateTime { get; set; } = DateTime.Now;
        public int ID_User { get; set; }
        public int ID_Book { get; set; }
        public User User { get; set; }
        public ICollection<OrderBook> OrderBook { get; set; }
    }
}