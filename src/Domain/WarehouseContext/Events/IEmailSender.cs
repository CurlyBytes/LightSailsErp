using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WarehouseContext.Events
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
