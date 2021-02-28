namespace SharedKernel.Rules
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}