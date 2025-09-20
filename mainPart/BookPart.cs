using _EF_Exam_Project_.entities;
using _EF_Exam_Project_.exception;
using _EF_Exam_Project_.service;
namespace _EF_Exam_Project_.mainPart
{
    public class BookPart
    {
        public static void BookMenu(BookService service, CategoryService catService, AuthorService authService)
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t Welcome to Book Part !\n\n");
                Console.ResetColor();

                Console.WriteLine("\n\t Add Book       : 1");
                Console.WriteLine("\n\t Delete Book    : 2");
                Console.WriteLine("\n\t Update Book    : 3");
                Console.WriteLine("\n\t Get All Books  : 4");
                Console.WriteLine("\n\t Get Book By Id : 5");
                Console.WriteLine("\n\t Back           : 6");
                Console.Write("\n\n\n");

                Console.Write("\n\t Enter choice (1/2/3/4/5/6) : ");
                string Choice = Console.ReadLine();
                Console.Write("\n\n");

                try
                {
                    switch (Choice)
                    {
                        case "1":
                            string BTitle_;

                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter book title : ");
                                Console.ResetColor();
                                BTitle_ = Console.ReadLine();

                                if(BTitle_.Length < 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\t\t Error ! Title maust have at least 3 characters ! \n");
                                    Console.ResetColor();
                                }
                            }
                            while (BTitle_.Length < 3);

                            Console.Write("\n\t Enter author id : ");
                            int AId_ = int.Parse(Console.ReadLine());

                            Console.Write("\n\t Enter category id : ");
                            int CId_ = int.Parse(Console.ReadLine());

                            bool CheckAdd = service.Add(new Book { Title = BTitle_, ID_Author = AId_, ID_Category = CId_ });

                            if(CheckAdd)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t\t Book added successfully ! \n");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Error adding book ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "2":
                            Console.Write("\n\t Enter book id : ");
                            int IdDel = int.Parse(Console.ReadLine());

                            bool CheckDel = service.Delete(IdDel);

                            if(CheckDel)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t\t Book deleted successfully ! \n");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Book not found ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "3":
                            Console.Write("\n\t Enter book id : ");
                            int UpId = int.Parse(Console.ReadLine());

                            var Book = service.ById(UpId);

                            if (Book != null)
                            {
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter book title : ");
                                    Console.ResetColor();
                                    Book.Title = Console.ReadLine();

                                    if (Book.Title.Length < 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Title maust have at least 3 characters ! \n");
                                        Console.ResetColor();
                                    }
                                }
                                while (Book.Title.Length < 3);

                                bool CheckUp = service.Update(UpId, Book);

                                if(CheckUp)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("\n\t\t Book updated successfully ! \n");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\t\t Error updating book ! \n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t\t Book not found ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "4":
                            foreach (var x in service.GelAll())
                            {
                                Console.WriteLine($"\n\t {x.ID} - {x.Title}");
                            }
                            Thread.Sleep(3000);
                            break;
                        case "5":
                            Console.Write("\n\t Enter id : ");
                            var Id = service.ById(int.Parse(Console.ReadLine()));

                            if (Id != null)
                            {
                                Console.WriteLine($"{Id.ID} - {Id.Title}");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Book not found ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(3000);
                            break;
                        case "6": 
                            return;
                    }
                }
                catch(ChoiceException ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
    }
}
