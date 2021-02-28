using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ardalis.GuardClauses
{
    public static class WarehouseGuardClause
    {
        public static void CodeNameRegex(this IGuardClause guardClause, string input, string parameterName)
        {
            Guard.Against.NullOrEmpty(input, nameof(input));
            Guard.Against.NullOrWhiteSpace(input, nameof(input));
            Regex regexPattern = new Regex(@"\b\w*[-']\w*\b");
            if (!regexPattern.IsMatch(input))
            {
                throw new ArgumentException("Invalid CodeName Structure.", parameterName);
            }
        }
    }
}