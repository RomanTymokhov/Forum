using System.Threading.Tasks;

namespace Forum.Domain.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
