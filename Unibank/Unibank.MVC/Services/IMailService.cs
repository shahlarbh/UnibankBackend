using Unibank.MVC.Data;

namespace Unibank.MVC.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(RequestEmail requestEmail);
    }
}
