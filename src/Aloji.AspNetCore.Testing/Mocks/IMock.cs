namespace Aloji.AspNetCore.Testing.Mocks
{
    public interface IMock
    {
        void Clear();
    }

    public interface IMock<TService> : IMock
        where TService : class
    {
        TService Instance { get; }
    }
}
