using _EF_Exam_Project_.context;
using _EF_Exam_Project_.exception;
using _EF_Exam_Project_.mainPart;
using _EF_Exam_Project_.service;
namespace EF_Finally_Exam_Project_
{
    public class Start
    {
        static void Main(string[] args)
        {
            while (true)
            {
                BookShopDataBase Db = new BookShopDataBase();
                UserService Us = new UserService(Db);

                try
                {
                    while (true)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\n\t\t Welcome to Book Shop \n\n");
                        Console.ResetColor();

                        Console.Write("\n\t Sign In         : 1");
                        Console.Write("\n\t Sign Up         : 2");
                        Console.Write("\n\t Forgot password : 3");
                        Console.Write("\n\t Exit            : 4");
                        Console.Write("\n\n\n");

                        Console.Write("\n\t Enter choice(1/2/3) : ");
                        string MainChoice = Console.ReadLine();

                        switch (MainChoice)
                        {
                            case "1":
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("\n\t\t Welcome to Sign In Part \n\n");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter username : ");
                                Console.ResetColor();
                                string In_Username = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter password : ");
                                Console.ResetColor();
                                string In_Password = Console.ReadLine();

                                Us.SignIn(In_Username, In_Password);

                                var _user = Db.Users.FirstOrDefault(x => x.Username == In_Username && x.Passsword == In_Password && !x.IsDeleted);
                                var os = new OrderService(Db);
                                var obs = new OrderBookService(Db);
                                var bs = new BookService(Db);

                                OrderPart.OrderMenu(os, obs, bs, _user);

                                Thread.Sleep(2000);
                                break;

                            case "2":
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("\n\t\t Welcome to Sign Up Part \n\n");
                                Console.ResetColor();

                                string Up_Name;

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter name (Min 3 characters) : ");
                                    Console.ResetColor();
                                    Up_Name = Console.ReadLine();

                                    if(Up_Name.Length < 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Name must have at least 3 characters ! \n");
                                        Console.ResetColor();
                                    }

                                } while (Up_Name.Length < 3);

                                string Up_Surname;

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter surname (Min 5 characters) : ");
                                    Console.ResetColor();
                                    Up_Surname = Console.ReadLine();

                                    if (Up_Surname.Length < 5)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Surname must have at least 5 characters ! \n");
                                        Console.ResetColor();
                                    }

                                } while (Up_Surname.Length < 5);

                                string Up_Username;

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter username (Min 5 characters) : ");
                                    Console.ResetColor();
                                    Up_Username = Console.ReadLine();

                                    if (Up_Username.Length < 5)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Userame must have at least 5 characters ! \n");
                                        Console.ResetColor();
                                    }

                                } while (Up_Username.Length < 5);

                                string Up_Email;

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter email : ");
                                    Console.ResetColor();
                                    Up_Email = Console.ReadLine();


                                    if (!Up_Email.Contains("@") || !Up_Email.Contains(".") || Up_Email.Length < 6)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Incorrect email ! \n");
                                        Console.ResetColor();
                                    }

                                } while (!Up_Email.Contains("@") || !Up_Email.Contains(".") || Up_Email.Length < 6);

                                string AppCode;

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter app code : ");
                                    Console.ResetColor();
                                    AppCode = Console.ReadLine();

                                    if(string.IsNullOrWhiteSpace(AppCode))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Incorrect app password ! \n");
                                        Console.ResetColor();
                                    }

                                } while (string.IsNullOrWhiteSpace(AppCode));

                                string Up_Password;

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\n\t Enter password (Min 6 characters) : ");
                                    Console.ResetColor();
                                    Up_Password = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(Up_Password) || Up_Password.Length < 6)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t Error ! Password must have at least 6 characters ! \n");
                                        Console.ResetColor();
                                    }

                                } while (string.IsNullOrWhiteSpace(Up_Password) || Up_Password.Length < 6);

                                Us.SignUp(Up_Name, Up_Surname, Up_Username, Up_Email, AppCode, Up_Password);
                                Thread.Sleep(2000);
                                break;

                            case "3":
                                Console.Clear();
                                
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("\n\t\t Welcome to Forgot password Part \n\n");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter email : ");
                                Console.ResetColor();
                                string R_Email = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\n\t Enter app code : ");
                                Console.ResetColor();
                                string R_AppCode = Console.ReadLine();

                                Us.ForgetPassword(R_Email, R_AppCode);
                                    break;

                            case "4":
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Exit ! \n");
                                Console.ResetColor();
                                Environment.Exit(0);
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t Error ! Incorrect choice ! \n");
                                Console.ResetColor();
                                Thread.Sleep(2000);
                                break;
                        }
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