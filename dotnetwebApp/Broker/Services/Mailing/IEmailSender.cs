using System.Threading.Tasks;

namespace Broker.Mailing
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
