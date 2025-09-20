using MailKit.Security;
using MimeKit;
using _EF_Exam_Project_.exception;
namespace _EF_Exam_Project_.email
{
    public class Mail
    {
        public bool Send(string senderemail, string apppassword, string receiveremail, string subject, string body)
        {
            try
            {
                var Message = new MimeMessage();
                Message.From.Add(new MailboxAddress("Book Shop", senderemail));
                Message.To.Add(new MailboxAddress("Receiver", receiveremail));
                Message.Subject = subject;
                Message.Body = new TextPart("plain") { Text = body };

                using (var Client = new MailKit.Net.Smtp.SmtpClient())
                {
                    Client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    try
                    {
                        Client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                        Client.Authenticate(senderemail, apppassword);
                        Client.Send(Message);
                        Client.Disconnect(true);
                    }
                    catch (System.Exception ex)
                    {
                        Console.Write(ex.Message);
                        return false;
                    }
                }
                return true;
            }
            catch (EmailException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
