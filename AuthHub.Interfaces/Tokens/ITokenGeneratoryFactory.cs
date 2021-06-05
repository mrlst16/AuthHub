namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenGeneratoryFactory
    {
        ITokenGenerator Get<T>()
            where T : ITokenGenerator;
    }
}
