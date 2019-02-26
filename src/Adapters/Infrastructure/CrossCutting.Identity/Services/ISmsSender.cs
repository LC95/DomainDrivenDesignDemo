using System.Threading.Tasks;

namespace Arch.Infrastructure.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
