using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Warehouse.Events
{
    public class NewWarehouseEvent : DomainEventBase
    {
        public BussinessWarehouseId BussinessWarehouseId { get; }

        public NewWarehouseEvent(BussinessWarehouseId bussinessWarehouseId)
        {
            BussinessWarehouseId = bussinessWarehouseId;
        }
    }
}
