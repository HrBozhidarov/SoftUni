using Sis.Framework.Services;

namespace Sis.Framework.Api
{
    public interface IMvcApplication
    {
        void Configure();

        void ConfigureServices(IDependencyContainer dependencyContainer);
    }
}
