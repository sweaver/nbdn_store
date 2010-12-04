using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicDependencyBuilders : DependencyBuilders
    {
        IDictionary<Type, DependencyBuilder> builders;

        public BasicDependencyBuilders(IDictionary<Type, DependencyBuilder> builders)
        {
            this.builders = builders;
        }

        public DependencyBuilder get_the_builder_to_build<Dependency>()
        {
            return builders[typeof(Dependency)];
        }
    }
}