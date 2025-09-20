using _EF_Exam_Project_.context;
using _EF_Exam_Project_.entities;
using _EF_Exam_Project_.Services;
using System.Net;
namespace _EF_Exam_Project_.service
{
    public class OrderBookService : BaseService
    {
        private readonly BookShopDataBase DataBase;

        public OrderBookService(BookShopDataBase database) : base(database)
        {
            DataBase = database;
        }
        public bool CreateOrder(int id, List<int> bookid)
        {
            var order = DataBase.Orders.FirstOrDefault(x => x.ID == id && !x.IsDeleted);

            if (order == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t Order not found !");
                Console.ResetColor();
                return false;
            }

            foreach (var i in bookid)
            {
                var book = DataBase.Books.FirstOrDefault(x => x.ID == i && !x.IsDeleted);

                if (book != null)
                {
                    var orderBook = new OrderBook
                    {
                        ID_Book = book.ID,
                        ID_Order = order.ID,
                        Price = book.Price,
                        Create = DateTime.Now,
                        Update = DateTime.Now,
                        IsDeleted = false,
                        ID_Author = book.ID_Author,
                        ID_Category = book.ID_Category
                    };

                    DataBase.OrderBook.Add(orderBook);
                }
            }

            DataBase.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t Books successfully added to the order !");
            Console.ResetColor();
            return true;
        }

        public List<OrderBook> Order_Book(int id)
        {
            return DataBase.OrderBook.Where(x => x.ID_Order == id && !x.IsDeleted).ToList();
        }
    }
}
