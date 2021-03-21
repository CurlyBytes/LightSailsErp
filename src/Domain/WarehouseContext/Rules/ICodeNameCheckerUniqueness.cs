using Domain.WarehouseContext.ValueObjects;

namespace Domain.WarehouseContext.Rules
{
    public interface ICodeNameCheckerUniqueness
    {
        bool IsUnique(CodeName codeName);
    }
}