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
            ensure_there_is_a_builder_for<Dependency>();
            return builders[typeof(Dependency)];
        }

        void ensure_there_is_a_builder_for<Dependency>()
        {
            if (builders.ContainsKey(typeof(Dependency))) return;

            throw new DependencyBuilderNotRegisteredException(typeof(Dependency));
        }
    }
}