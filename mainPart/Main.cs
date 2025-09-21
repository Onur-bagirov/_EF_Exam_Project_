using _EF_Exam_Project_.context;
using _EF_Exam_Project_.entities;
using _EF_Exam_Project_.exception;
using _EF_Exam_Project_.service;
namespace _EF_Exam_Project_.mainPart
{
    public class MainPart
    {
        public static void MainStart(User currentUser)
        {
            using var db = new BookShopDataBase();
            var categoryService = new CategoryService(db);
            var authorService = new AuthorService(db);
            var bookService = new BookService(db);
            var orderService = new OrderService(db);
            var orderBookService = new OrderBookService(db);

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t Welcome to Book Shop \n\n");
                Console.ResetColor();

                Console.WriteLine("\n\t Manage Categories : 1");
                Console.WriteLine("\n\t Manage Authors    : 2");
                Console.WriteLine("\n\t Manage Books      : 3");
                Console.WriteLine("\n\t Manage Orders     : 4");
                Console.WriteLine("\n\t Exit              : 5");
                Console.Write("\n\n\n");

                Console.Write("\n\t Enter choice (1/2/3/4/5) : ");
                string Choice = Console.ReadLine();

                try
                {
                    switch (Choice)
                    {
                        case "1":
                            CategoryPart.CategoryMenu(categoryService);
                            break;
                        case "2":
                            AuthorPart.AuthorMenu(authorService);
                            break;
                        case "3":
                            BookPart.BookMenu(bookService, categoryService, authorService);
                            break;
                        case "4":
                            OrderPart.OrderMenu(orderService, orderBookService, bookService,currentUser);
                            break;
                        case "5":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\t\t Exit ! \n");
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\t\t Error ! Incorrect choice !c\n");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                            break;
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
