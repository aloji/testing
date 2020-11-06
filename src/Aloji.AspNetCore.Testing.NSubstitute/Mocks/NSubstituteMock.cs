using NSubstitute.ClearExtensions;
using System;

namespace Aloji.AspNetCore.Testing.Mocks
{
    public class NSubstituteMock<TService> : IMock<TService>
       where TService : class
    {
        public TService Instance { get; private set; }
        protected Action<TService> DefaultSubstitute { get; set; }

        public NSubstituteMock()
        {
            this.Instance = NSubstitute.Substitute.For<TService>();
        }

        public NSubstituteMock(Action<TService> defaultSubstitute) 
            : this()
        {
            this.DefaultSubstitute = defaultSubstitute;
        }

        public virtual void Clear()
        {
            this.Instance.ClearSubstitute();
            this.DefaultSubstitute?.Invoke(this.Instance);
        }
    }
}
