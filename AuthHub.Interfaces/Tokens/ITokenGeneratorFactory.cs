namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenGeneratorFactory
    {
        ITokenGenerator Get<T>()
            where T : ITokenGenerator;
    }
}
