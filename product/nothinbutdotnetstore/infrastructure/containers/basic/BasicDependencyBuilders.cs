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
            //if (builders[typeof(Dependency)] == null) throw new DependencyBuilderNotRegisteredException();
            guard_against_a_builder_not_in_the_dictionary<Dependency>();
            return builders[typeof (Dependency)];
        }

        private void guard_against_a_builder_not_in_the_dictionary<Dependency>()
        {
            if (!builders.ContainsKey(typeof(Dependency))) throw new DependencyBuilderNotRegisteredException();
            return;
        }
    }
}