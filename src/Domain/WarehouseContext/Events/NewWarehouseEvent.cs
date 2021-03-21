using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Events
{
    public class NewWarehouseEvent : DomainEventBase
    {
        public BussinessWarehouse NewWarehouse { get; }

        public NewWarehouseEvent(BussinessWarehouse newWarehouse)
        {
            NewWarehouse = newWarehouse;
        }
    }
}
