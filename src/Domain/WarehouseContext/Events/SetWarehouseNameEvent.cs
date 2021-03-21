using SharedKernel.Events;

namespace Domain.WarehouseContext.Events
{
    public class SetWarehouseNameEvent : DomainEventBase
    {
        public string WarehouseName { get; }

        public SetWarehouseNameEvent(string warehouseName)
        {
            WarehouseName = warehouseName;
        }
    }
}