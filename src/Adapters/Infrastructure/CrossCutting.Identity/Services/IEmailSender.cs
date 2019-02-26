using System.Threading.Tasks;

namespace Arch.Infrastructure.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
