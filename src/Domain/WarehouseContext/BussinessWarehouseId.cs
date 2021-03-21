using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext
{
    public class BussinessWarehouseId : TypedIdValueBase
    {
        public BussinessWarehouseId(Guid value) : base(value)
        {
        }
    }
}
