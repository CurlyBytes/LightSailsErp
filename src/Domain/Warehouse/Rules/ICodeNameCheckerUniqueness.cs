using Domain.Warehouse.ValueObjects;

namespace Domain.Warehouse.Rules
{
    public interface ICodeNameCheckerUniqueness
    {
        bool IsUnique(CodeName codeName);
    }
}