using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicDependencyBuilder : DependencyBuilder
    {
        Func<object> factory;

        public BasicDependencyBuilder(Func<object> factory)
        {
            this.factory = factory;
        }

        public object build()
        {
            return factory.Invoke();
        }
    }
}