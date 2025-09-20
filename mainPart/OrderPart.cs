using _EF_Exam_Project_.entities;
using _EF_Exam_Project_.exception;
using _EF_Exam_Project_.service;
namespace _EF_Exam_Project_.mainPart
{
    public class OrderPart
    {
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
                            Console.Write("\n\t Enter book id : ");
                            int BId = int.Parse(Console.ReadLine());

                            var Book = bookService.ById(BId);

                            if (Book != null)
                            {
                                var newOrder = new Order
                                {
                                    OrderDateTime = DateTime.Now,
                                    ID_User = _user.ID,
                                    Price = Book.Price,
                                    Create = DateTime.Now,
                                    Update = DateTime.Now,
                                    IsDeleted = false
                                };

                                var Order = new Order { OrderDateTime = DateTime.Now };
                                orderService.Add(Order);

                                bool CheckOr = orderBookService.CreateOrder(Order.ID, new List<int> { BId });

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
                            break;
                        case "2":
                            Console.Write("\n\t Enter order id : ");
                            int OId = int.Parse(Console.ReadLine());

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
                            foreach (var x in orderService.GetAll())
                            {
                                Console.WriteLine($"\n\t {x.ID} - {x.Price}");
                            }

                            Thread.Sleep(3000);
                            break;
                        case "4":
                            Console.Write("\n\t Enter order id : ");
                            var Oid = orderService.ById(int.Parse(Console.ReadLine()));

                            if (Oid != null)
                            {
                                Console.WriteLine($"{Oid.ID} - {Oid.OrderDateTime}");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t\t Order not found ! \n");
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
