using Ninject;
using ServiceStack.Configuration;

namespace Accounting.Data
{
    public class NinjectIocAdapter : IContainerAdapter
    {
        private readonly IKernel kernel;

        public NinjectIocAdapter(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T Resolve<T>()
        {
            return this.kernel.Get<T>();
        }

        public T TryResolve<T>()
        {
            return this.kernel.CanResolve<T>() ? this.kernel.Get<T>() : default(T);
        }
    }
}
