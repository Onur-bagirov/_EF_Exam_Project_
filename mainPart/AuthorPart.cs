using _EF_Exam_Project_.entities;
using _EF_Exam_Project_.exception;
using _EF_Exam_Project_.service;
namespace _EF_Exam_Project_.mainPart
{
    public class AuthorPart
    {
        public static void AuthorMenu(AuthorService service)
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t Welcome to Author Part ! \n\n");
                Console.ResetColor();

                Console.WriteLine("\n\t Add Author       : 1");
                Console.WriteLine("\n\t Delete Author    : 2");
                Console.WriteLine("\n\t Update Author    : 3");
                Console.WriteLine("\n\t Get All Authors  : 4");
                Console.WriteLine("\n\t Get Author By Id : 5");
                Console.WriteLine("\n\t Back             : 6");
                Console.Write("\n\n\n");

                Console.Write("\n\t Enter choice (1/2/3/4/5/6) : ");
                string Choice = Console.ReadLine();
                Console.Write("\n\n");

                try
                {
                    switch (Choice)
                    {
                        case "1":

                            string Name;

                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("\n\t Enter name (Min 3 characters) : ");
                                Console.ResetColor();
                                Name = Console.ReadLine();

                                if (Name.Length < 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\t\t Error ! Name maust have at least 3 characters ! \n");
                                    Console.ResetColor();
                                }
                            }
                            while (Name.Length < 3);

                            string Surname;

                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("\n\t Enter surname  (Min 5 characters) : ");
                                Console.ResetColor();
                                Surname = Console.ReadLine();

                                if (Name.Length < 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\t\t Error ! Surname maust have at least 5 characters ! \n");
                                    Console.ResetColor();
                                }
                            }
                            while (Surname.Length < 5);


                            bool CheckAdd = service.Add(new Author { Name = Name, Surname = Surname });

                            if(CheckAdd)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t\t Author added successfully ! \n");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Error adding author ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "2":
                            Console.Write("\n\t Enter author id : ");
                            int IdDel = int.Parse(Console.ReadLine());

                            bool CheckDel = service.Delete(IdDel);

                            if (CheckDel)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t\t Author deleted successfully ! \n");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Error ! Author not found ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "3":
                            Console.Write("\n\t Enter author id : ");
                            int UpId = int.Parse(Console.ReadLine());

                            var Update = service.ById(UpId);

                            if (Update != null)
                            { 
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter name (Min 3 characters) : ");
                                    Console.ResetColor();
                                    Update.Name = Console.ReadLine();

                                    if (Update.Name.Length < 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Name maust have at least 3 characters ! \n");
                                        Console.ResetColor();
                                    }
                                }
                                while (Update.Name.Length < 3);

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter surname  (Min 5 characters) : ");
                                    Console.ResetColor();
                                    Update.Surname = Console.ReadLine();

                                    if (Update.Surname.Length < 5)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Surname maust have at least 5 characters ! \n");
                                        Console.ResetColor();
                                    }
                                }
                                while (Update.Surname.Length < 5);

                                bool CheckUp = service.Update(UpId, Update);

                                if (CheckUp)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("\n\t\t Author updated successfully ! \n");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\t\t Error updating author !");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t\t Author not found ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "4":
                            foreach (var x in service.GelAll())
                            {
                                Console.WriteLine($"\n\t {x.ID} - {x.Name} {x.Surname}");
                            }
                            Thread.Sleep(3000);
                            break;
                        case "5":
                            Console.Write("\n\t Enter id : ");
                            var IdUp= service.ById(int.Parse(Console.ReadLine()));
                            if (IdUp != null)
                            {
                                Console.WriteLine($"\n\t {IdUp.ID} - {IdUp.Name} {IdUp.Surname}");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t\t Error ! Author not found ! \n");
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
