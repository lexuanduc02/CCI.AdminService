using CCI.Service.Contractors;

namespace CCI.Service
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string toEmail, string subject, string body, bool isHtml = false)
        {
            throw new NotImplementedException();
        }
    }
}
