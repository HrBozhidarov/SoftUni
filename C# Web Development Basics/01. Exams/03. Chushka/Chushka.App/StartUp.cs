using SIS.MvcFramework;
using SIS.MvcFramework.Services;

namespace Chushka.App
{
    public class StartUp : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {

        }
    }
}
