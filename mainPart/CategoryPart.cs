using _EF_Exam_Project_.context;
using _EF_Exam_Project_.service;
using _EF_Exam_Project_.exception;
namespace _EF_Exam_Project_.mainPart
{
    public class CategoryPart
    {
        public static void CategoryMenu(CategoryService service)
        {
            using var DataBase = new BookShopDataBase();

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t Welcome to Category Part !\n\n");
                Console.ResetColor();

                Console.WriteLine("\n\t Add Category       : 1");
                Console.WriteLine("\n\t Delete Category    : 2");
                Console.WriteLine("\n\t Update Category    : 3");
                Console.WriteLine("\n\t Get All Categories : 4");
                Console.WriteLine("\n\t Get Category By Id : 5");
                Console.WriteLine("\n\t Back               : 6");
                Console.Write("\n\n\n");

                Console.Write("\n\t Enter choice (1/2/3/4/5/6) : ");
                string Choice = Console.ReadLine();
                Console.Write("\n\n");

                try
                {
                    switch (Choice)
                    {
                        case "1":
                            Console.Clear();
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter name (Min 3 characters) : ");
                                Console.ResetColor();
                                Name = Console.ReadLine();

                                if(Name.Length < 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\t\t Error ! Name must have at least 3 characters ! \n");
                                    Console.ResetColor();
                                }
                            }
                            while (Name.Length < 3);

                            bool CheckAdd = service.Add(new entities.Category { Name = Name });

                            if(CheckAdd)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t\t Category added successfully ! \n");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Error adding category ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "2":
                            Console.Clear();
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter category id : ");
                                Console.ResetColor();
                                string input = Console.ReadLine();

                                if (!int.TryParse(input, out Id) || Id <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t\t Error ! Please enter a valid positive number ! \n");
                                    Console.ResetColor();
                                    Id = -1;
                                }
                            } while (Id <= 0);

                            bool CheckDel = service.Delete(Id);

                            if(CheckDel)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t\t Ctategory deleted successfully ! \n");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Category not found ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "3":
                            int UpId;
                            Console.Clear();
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter category id : ");
                                Console.ResetColor();
                                string input = Console.ReadLine();

                                if (!int.TryParse(input, out UpId) || UpId <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t\t Error ! Please enter a valid positive number ! \n");
                                    Console.ResetColor();
                                    UpId = 0;
                                }
                            } while (UpId <= 0);

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
                                        Console.Write("\n\t\t Error ! Name must have at least 3 characters ! \n");
                                        Console.ResetColor();
                                    }

                                } while (Update.Name.Length < 3);

                                bool CheckUp = service.Update(UpId, Update);

                                if(CheckUp)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("\n\t\t Category updated successfully ! \n");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\t\t Error updating category ! \n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t\t Category not found ! \n");
                                Console.ResetColor();
                            }
                            Thread.Sleep(1500);
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("\n\t All Categories : ");

                            foreach (var x in service.GetAll())
                            {
                                Console.WriteLine($"\n\t {x.ID} - {x.Name}");
                            }
                            Thread.Sleep(3000);
                            break;
                        case "5":
                            int id;
                            Console.Clear();
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter id : ");
                                Console.ResetColor();
                                string input = Console.ReadLine();

                                if (!int.TryParse(input, out id) || id <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t\t Error! Please enter a valid positive number!\n");
                                    Console.ResetColor();
                                }
                            } while (id <= 0);

                            var Check = service.ById(id);

                            if (Check != null)
                            {
                                Console.WriteLine($"\n\t {Check.ID} - {Check.Name}");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t\t Category not found ! \n");
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
