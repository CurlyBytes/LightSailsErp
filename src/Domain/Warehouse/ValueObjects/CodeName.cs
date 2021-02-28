using Ardalis.GuardClauses;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Warehouse.ValueObjects
{
    public class CodeName : ValueObject
    {
        public string Code { get; private set; }

        public CodeName(string code)
        {
            
            Guard.Against.NullOrEmpty(code, nameof(code));
            Guard.Against.NullOrWhiteSpace(code, nameof(code));
            Guard.Against.CodeNameRegex(code, nameof(code));
           
            Code = code ?? throw new ArgumentNullException(nameof(code));

        }

        public override string ToString()
        {

            return Code;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code.ToUpper().Trim();

        }
    }
}
