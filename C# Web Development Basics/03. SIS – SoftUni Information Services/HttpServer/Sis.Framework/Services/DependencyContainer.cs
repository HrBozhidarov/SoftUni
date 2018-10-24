namespace Sis.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<Type, Type> dependancyDictionary;

        public DependencyContainer()
        {
            this.dependancyDictionary = new Dictionary<Type, Type>();
        }

        private Type this[Type key]
        {
            get => this.dependancyDictionary.ContainsKey(key) ? this.dependancyDictionary[key] : null;
        }

        public T CreateInstance<T>()
            => (T)this.CreateInstance(typeof(T));

        public object CreateInstance(Type type)
        {
            var instanceType = this[type] ?? type;

            if (instanceType.IsAbstract || instanceType.IsInterface)
            {
                throw new InvalidOperationException($"Type {instanceType.FullName} can not be instantiated.");
            }

            var constructor = instanceType.GetConstructors().OrderBy(x => x.GetParameters().Length).First();
            var constructorParameters = constructor.GetParameters();
            var constructorObjectParameters = new object[constructorParameters.Length];

            for (int i = 0; i < constructorParameters.Length; i++)
            {
                constructorObjectParameters[i] = this.CreateInstance(constructorParameters[i].ParameterType);
            }

            return constructor.Invoke(constructorObjectParameters);
        }

        public void RegisterDependecny<TSource, TDestination>()
        {
            this.dependancyDictionary[typeof(TSource)] = typeof(TDestination);
        }
    }
}
