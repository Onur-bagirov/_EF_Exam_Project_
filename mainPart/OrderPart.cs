using _EF_Exam_Project_.entities;
using _EF_Exam_Project_.exception;
using _EF_Exam_Project_.service;
namespace _EF_Exam_Project_.mainPart
{
    public class OrderPart
    {
        private static Random Code_Random = new Random();
        public static int Price()
        {
            return Code_Random.Next(10, 21); 
        }
        public static void OrderMenu(OrderService orderService, OrderBookService orderBookService, BookService bookService, User _user)
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t Welcome to Order Part !\n\n");
                Console.ResetColor();

                Console.WriteLine("\n\t Create Order    : 1");
                Console.WriteLine("\n\t Delete Order    : 2");
                Console.WriteLine("\n\t Get All Orders  : 3");
                Console.WriteLine("\n\t Get Order By Id : 4");
                Console.WriteLine("\n\t Back            : 5");
                Console.Write("\n\n\n");

                Console.Write("\n\t Enter choice (1/2/3/4/5) : ");
                string Choice = Console.ReadLine();
                Console.Write("\n\n");

                try
                {
                    switch (Choice)
                    {
                        case "1":
                            int BId;
                            Console.Clear();
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter book id : ");
                                Console.ResetColor();
                                string input = Console.ReadLine();

                                if (!int.TryParse(input, out BId) || BId <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t\t Error ! Please enter a valid positive number ! \n");
                                    Console.ResetColor();
                                    BId = -1;
                                }
                            } while (BId <= 0);                       

                            var Book = bookService.ById(BId);

                            if (Book != null)
                            {
                                Book.Price = Price();
                                var newOrder = new Order
                                {
                                    OrderDateTime = DateTime.Now,
                                    ID_User = _user.ID,
                                    Price = Book.Price,
                                    Create = DateTime.Now,
                                    Update = DateTime.Now,
                                    IsDeleted = false,
                                    ID_Book = Book.ID
                                };
                                orderService.Add(newOrder,_user);

                                bool CheckOr = orderBookService.CreateOrder(newOrder.ID, new List<int> { BId });

                                if (CheckOr)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("\n\t\t Order created successfully ! \n");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\t\t Error creating order ! \n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t\t Book not found ! \n");
                                Console.ResetColor();
                                Thread.Sleep(1500);
                            }
                            Thread.Sleep(1500);
                            break;
                        case "2":
                            int OId;
                            Console.Clear();
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter order id : ");
                                Console.ResetColor();
                                string input = Console.ReadLine();

                                if (!int.TryParse(input, out OId) || OId <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t\t Error ! Please enter a valid positive number ! \n");
                                    Console.ResetColor();
                                    OId = -1;
                                }
                            } while (OId <= 0);

                            bool CheckOR = orderService.Delete(OId);

                            if (CheckOR)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t\t Order deleted successfully ! \n");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Error delete order ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "3":
                            Console.Clear();
                            foreach (var x in orderService.GetAll())
                            {
                                var book = bookService.ById(x.ID_Book);
                                Console.WriteLine($"\n\t OrderID : {x.ID} | Price : {x.Price} | Book Name : {book.Title} | UserID : {x.ID_User}");
                            }
                            Thread.Sleep(3000);
                            break;
                        case "4":
                            Console.Clear();
                            int TempId;

                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter order id : ");
                                Console.ResetColor();

                                string input = Console.ReadLine();

                                if (!int.TryParse(input, out TempId) || TempId <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t\t Error ! Please enter a valid positive number ! \n");
                                    Console.ResetColor();
                                }
                                else break;
                            }

                            var orderById = orderService.ById(TempId);

                            if (orderById != null)
                            {
                                var orderBooks = orderBookService.Order_Book(orderById.ID);

                                foreach (var ob in orderBooks)
                                {
                                    var book = bookService.ById(ob.ID_Book);
                                    Console.WriteLine(
                                        $"\n\t OrderID : {orderById.ID} | Time : {orderById.OrderDateTime} | Price : {orderById.Price} | Book Name : {book.Title} | UserID : {orderById.ID_User}"
                                    );
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t\t Error ! Order not found ! \n");
                                Console.ResetColor();
                            }

                            Thread.Sleep(3000);
                            break;

                        case "5": 
                            return;
                    }
                }
                catch (ChoiceException ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
    }
}
