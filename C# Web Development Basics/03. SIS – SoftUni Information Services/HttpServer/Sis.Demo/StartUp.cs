namespace Sis.Demo
{
    using Sis.Demo.Services;
    using Sis.Framework.Api;
    using Sis.Framework.Services;

    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependecny<IHomeService, HomeService>();
        }
    }
}
