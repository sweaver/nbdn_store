 using System;
 using System.Collections.Generic;
 using System.Data;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
{   
    public class DependencyBuildersSpecs
    {
        public abstract class concern : Observes<DependencyBuilders,
                                            BasicDependencyBuilders>
        {
        
        }

        [Subject(typeof(BasicDependencyBuilders))]
        public class when_getting_the_dependency_builder_for_a_type_and_it_has_the_builder : concern
        {
            Establish c = () =>
            {
                the_builder_that_can_create_connections = an<DependencyBuilder>();
                dependency_builders = new Dictionary<Type,DependencyBuilder>();
                dependency_builders.Add(typeof(IDbConnection),the_builder_that_can_create_connections);

                provide_a_basic_sut_constructor_argument(dependency_builders);
            };

            Because b = () =>
                result = sut.get_the_builder_to_build<IDbConnection>();



            It should_return_the_builder_to_the_caller = () =>
                result.ShouldEqual(the_builder_that_can_create_connections);


            static DependencyBuilder result;
            static DependencyBuilder the_builder_that_can_create_connections;
            static IDictionary<Type, DependencyBuilder> dependency_builders;
        }
    }
}
