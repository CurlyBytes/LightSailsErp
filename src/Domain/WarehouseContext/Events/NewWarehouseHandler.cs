using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.WarehouseContext.Events
{
    public class NewWarehouseHandler : INotificationHandler<NewWarehouseEvent>
    {
        private readonly IEmailSender _emailSender;

        public NewWarehouseHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        // configure a test email server to demo this works
        // https://ardalis.com/configuring-a-local-test-email-server
        public Task Handle(NewWarehouseEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            return _emailSender.SendEmailAsync("test@test.com", "test@test.com", $"{domainEvent.NewWarehouse} was completed.", domainEvent.NewWarehouse.ToString());
        }
    }
}
