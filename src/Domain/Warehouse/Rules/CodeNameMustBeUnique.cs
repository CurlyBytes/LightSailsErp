using Domain.Warehouse.ValueObjects;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Warehouse.Rules
{
    public class CodeNameMustBeUnique : IBusinessRule
    {
        private readonly ICodeNameCheckerUniqueness _iCodeNameCheckerUniqueness;

        private readonly CodeName _codeName;
        public CodeNameMustBeUnique(
            ICodeNameCheckerUniqueness iCodeNameCheckerUniqueness,
            CodeName codeName)
        {
            _iCodeNameCheckerUniqueness = iCodeNameCheckerUniqueness;
            _codeName = codeName;
        }
       
        public string Message => "Warehouse with this Codename already exists.";

        public bool IsBroken() => !_iCodeNameCheckerUniqueness.IsUnique(_codeName);
    }
}
