namespace _EF_Exam_Project_.exception
{
    public class EmailException : System.Exception
    {
        public EmailException()
          : base("An error occurred while sending the email !")
        {
        }
    }
}
