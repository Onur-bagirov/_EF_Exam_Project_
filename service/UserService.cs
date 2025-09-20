using _EF_Exam_Project_.context;
using _EF_Exam_Project_.email;
using _EF_Exam_Project_.entities;
using _EF_Exam_Project_.mainPart;
namespace _EF_Exam_Project_.service
{
    public class UserService
    {
        private Mail EmailService;
        private BookShopDataBase DataBase;
        public UserService(BookShopDataBase database)
        {
            DataBase = database;
            EmailService = new Mail();
        }
        public string RandomCode()
        {
            var Code_Random = new Random();
            return Code_Random.Next(100000, 1000000).ToString();
        }
        public bool SignIn(string username, string password)
        {
            if (DataBase.Users.Any(x =>x.Username == username && x.Passsword == password))
            {
                MainPart.MainStart();
                Thread.Sleep(2000);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t Error ! Incorrect username or password ! \n");
                Console.ResetColor();
                Thread.Sleep(2000);
                return false;
            }
        }
        public bool SignUp(string surname, string name, string username, string email, string appcode, string password)
        {
            string Random_Code = RandomCode();

            bool SentEmail = EmailService.Send
            (
                senderemail: email,
                apppassword: appcode,
                receiveremail: email,
                subject: "Your Confirmation Code",
                body: $"Your confirmation code is : {Random_Code}"
            );

            if (!SentEmail)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t Email could not be sent !  Incorrect email or app code ! \n");
                Console.ResetColor();
                Thread.Sleep(2000);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\t\t Confirmation code has been sent to your email ! \n");
            Console.ResetColor();
            Thread.Sleep(2000);

            int Attempts = 3;

            while (Attempts > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\n\t Enter the confirmation code : ");
                Console.ResetColor();
                string UPConfirmationCode = Console.ReadLine();

                if (UPConfirmationCode == Random_Code)
                {
                    var NewUser = new User { Name = name, Surname = surname, Username = username, Email = email, Passsword = password, Create = DateTime.Now, Update = DateTime.Now, Delete = DateTime.MinValue, IsDeleted = false };

                    DataBase.Users.Add(NewUser);
                    DataBase.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n\t\t Sign Up successful ! Welcome, {username} ! \n");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    return true;
                }
                else
                {
                    Attempts--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t Incorrect code ! Try again ! \n");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t Registration failed ! You entered incorrect code too many times ! \n");
            Console.ResetColor();
            Thread.Sleep(2000);
            return false;
        }
        public bool ForgetPassword(string email, string appcode)
        {
            var User = DataBase.Users.FirstOrDefault(x => x.Email == email);

            if (User == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t User not found ! \n");
                Console.ResetColor();
                return false;
            }

            string RandomCode_ = RandomCode();

            bool SentEmail = EmailService.Send
            (
                senderemail: email,
                apppassword: appcode,
                receiveremail: User.Email,
                subject: "Password Reset Code",
                body: $"Your password reset code is : {RandomCode_}"
            );

            if (!SentEmail)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t Email could not be sent ! \n");
                Console.ResetColor();
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\t\t Reset code sent to your email ! \n");
                Console.ResetColor();
            }

            int Attempts = 3;

            while (Attempts > 0)
            {
                Console.Write("\n\t Enter confirmation code : ");
                string ForgetConfirmationCode = Console.ReadLine();

                if (ForgetConfirmationCode == RandomCode_)
                {
                    Console.Write("\n\t Enter new password : ");
                    string NewPassword = Console.ReadLine();

                    User.Passsword = NewPassword;
                    DataBase.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t\t Password has been reset successfully ! \n");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    Attempts--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t Incorrect code ! Try again ! \n");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t Error ! \n");
            Console.ResetColor();
            return false;
        }
    }
}
