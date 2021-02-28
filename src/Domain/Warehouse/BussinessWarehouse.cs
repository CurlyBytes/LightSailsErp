using Ardalis.GuardClauses;
using Domain.Warehouse.Rules;
using Domain.Warehouse.ValueObjects;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Warehouse
{
    public class BussinessWarehouse : Entity, IAggregateRoot
    {
        public string WarehouseName { get; private set; }
        public CodeName CodeName { get; private set; }

        private BussinessWarehouse(
            string warehouseName,
            CodeName codeName)
        {
            WarehouseName = warehouseName;
            CodeName = codeName;
        }

        public static BussinessWarehouse NewWarehouse(
            string warehouseName,
            CodeName codeName,
            ICodeNameCheckerUniqueness iCodeNameCheckerUniqueness)
        {

            CheckRule(new CodeNameMustBeUnique(iCodeNameCheckerUniqueness, codeName));

            return new BussinessWarehouse(warehouseName, codeName);
        }
    }
}
