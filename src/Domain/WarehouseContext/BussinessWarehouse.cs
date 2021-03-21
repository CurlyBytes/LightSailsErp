using Ardalis.GuardClauses;
using Domain.WarehouseContext.ValueObjects;
using Domain.WarehouseContext.Events;
using Domain.WarehouseContext.Rules;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext
{
    public class BussinessWarehouse : Entity, IAggregateRoot
    {
    
        public BussinessWarehouseId BussinessWarehouseId{ get; private set; }

        public string WarehouseName { get; private set; }
        public CodeName CodeName { get; private set; }

        private BussinessWarehouse(
            string warehouseName,
            CodeName codeName)
        {
            BussinessWarehouseId = new BussinessWarehouseId(Guid.NewGuid());
            SetWarehouseName(warehouseName);
            SetCodeName(codeName);

            AddDomainEvent(new NewWarehouseEvent(this));
        }




        protected void SetWarehouseName(
            string warehouseName)
        {
            const string regexPatternWareHouseName = @"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$";

            Guard.Against.NullOrEmpty(warehouseName, nameof(warehouseName));
            Guard.Against.NullOrWhiteSpace(warehouseName, nameof(warehouseName));
            Guard.Against.InvalidFormat(warehouseName, nameof(warehouseName), regexPatternWareHouseName);

            WarehouseName = warehouseName;

           // AddDomainEvent(new SetWarehouseNameEvent(warehouseName));
        }

        protected void SetCodeName(
            CodeName codeName)
        {
            CodeName = codeName;
           // AddDomainEvent(new SetCodeNameEvent(warehouseName));
        }

        public override string ToString()
        {
            return $"Warehouse name of { WarehouseName } with id { BussinessWarehouseId }  ";
        }

        //factories
        public static BussinessWarehouse Create(
                 string warehouseName,
                 CodeName codeName,
                 ICodeNameCheckerUniqueness iCodeNameCheckerUniqueness)
        {
            Guard.Against.InvalidInput(codeName, nameof(codeName), iCodeNameCheckerUniqueness.IsUnique);

            return new BussinessWarehouse(warehouseName, codeName);
        }
    }
}
