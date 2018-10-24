namespace Sis.Framework.Services
{
    using System;

    public interface IDependencyContainer
    {
        void RegisterDependecny<TSource, TDestination>();

        T CreateInstance<T>();

        object CreateInstance(Type type);
    }
}
