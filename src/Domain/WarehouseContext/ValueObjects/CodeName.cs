using Ardalis.GuardClauses;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.ValueObjects
{
    public class CodeName : ValueObject
    {
        public string Code { get; private set; }

        public CodeName(string code)
        {
            string regexPattern = @"\b\w*[-']\w*\b";
            Guard.Against.NullOrEmpty(code, nameof(code));
            Guard.Against.NullOrWhiteSpace(code, nameof(code));
            Guard.Against.InvalidFormat(code, nameof(code), regexPattern);
            Guard.Against.InvalidInput(code, nameof(code), CannotMoreThanTenCharacter);


            Code = code ?? throw new ArgumentNullException(nameof(code));

        }
        public bool CannotMoreThanTenCharacter(string tests) => tests.Length <= 10;

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
