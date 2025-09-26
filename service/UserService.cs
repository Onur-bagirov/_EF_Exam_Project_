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
        public User? SignIn(string username, string password)
        {
            var UsernameHash = HashCode.ToSha256(username.Trim());
            var PasswordHash = HashCode.ToSha256(password);

            var user = DataBase.Users.FirstOrDefault(x => x.Username == UsernameHash && x.Passsword == PasswordHash);

            if (user != null)
            {
                return user;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t Error ! Incorrect username or password ! \n");
                Console.ResetColor();
                Thread.Sleep(2000);
                return null;
            }
        }
        public bool SignUp(string surname, string name, string username, string email,string password)
        {
            string Random_Code = RandomCode();
            string UsernameHash = HashCode.ToSha256(username.Trim());
            var PasswordHash = HashCode.ToSha256(password);

            bool SentEmail = EmailService.Send
            (
                senderemail: "onurrmoskowaa2008@gmail.com",
                apppassword: "hyeeczeqwwjyegek",
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
                    var NewUser = new User { Name = name, Surname = surname, Username = UsernameHash, Email = email, Passsword = PasswordHash, Create = DateTime.Now, Update = DateTime.Now, Delete = DateTime.MinValue, IsDeleted = false };

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
        public bool ForgetPassword(string email)
        {
            var User = DataBase.Users.FirstOrDefault(x => x.Email == email);

            if (User == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t User not found ! \n");
                Console.ResetColor();
                Thread.Sleep(2000);
                return false;
            }

            string RandomCode_ = RandomCode();

            bool SentEmail = EmailService.Send
            (
                senderemail: "onurrmoskowaa2008@gmail.com",
                apppassword: "hyeeczeqwwjyegek",
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

            Console.Write("\n\t Enter confirmation code : ");
            string ForgetConfirmationCode = Console.ReadLine();

            while (true)
            {

                if (ForgetConfirmationCode == RandomCode_)
                {
                    string NewPassword;

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n\t Enter new password (Min 6 characters) : ");
                        Console.ResetColor();
                        NewPassword = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(NewPassword) || NewPassword.Length < 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\t\t Error ! Password must have at least 6 characters ! \n");
                            Console.ResetColor();
                        }

                    } 
                    while (string.IsNullOrWhiteSpace(NewPassword) || NewPassword.Length < 6);

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\t Confirm new password : ");
                    Console.ResetColor();
                    string NewPassword_ = Console.ReadLine();

                    if (NewPassword == NewPassword_)
                    {

                        User.Passsword = HashCode.ToSha256(NewPassword);
                        DataBase.SaveChanges();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\t\t Password has been reset successfully ! \n");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        return true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t  Unsuccessful try ! Try again ! \n");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
