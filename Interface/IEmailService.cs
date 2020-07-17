using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;

namespace EmailService.Interface
{
    public interface IEmailService
    {
        Task<Response> SendEmailAsync(List<string> to, List<string> cc, string subject, string message);

    }
}
