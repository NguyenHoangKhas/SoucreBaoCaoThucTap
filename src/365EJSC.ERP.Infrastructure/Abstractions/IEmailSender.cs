using _365EJSC.ERP.Infrastructure.DTOs.Email;

namespace _365EJSC.ERP.Infrastructure.Abstractions
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailRequest toEmail);
    }
}
