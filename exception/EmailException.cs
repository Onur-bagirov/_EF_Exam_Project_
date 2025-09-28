namespace _EF_Exam_Project_.exception
{
    public class EmailException : System.Exception
    {
        public EmailException()
          : base("\n\t\t An error occurred while sending the email ! \n\n")
        {
        }
    }
}
