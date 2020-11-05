using NSubstitute.ClearExtensions;

namespace Aloji.AspNetCore.Testing.Mocks
{
    public class NSubstituteMock<TService> : IMock<TService>
       where TService : class
    {
        public TService Instance { get; private set; }

        public NSubstituteMock()
        {
            this.Instance = NSubstitute.Substitute.For<TService>();
        }

        public virtual void Clear()
        {
            this.Instance.ClearSubstitute();
        }
    }
}
