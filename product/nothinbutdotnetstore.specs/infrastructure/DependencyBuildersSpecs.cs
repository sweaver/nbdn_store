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
            Establish c = () =>
            {
                dependency_builders = new Dictionary<Type, DependencyBuilder>();
                provide_a_basic_sut_constructor_argument(dependency_builders);
            };

            protected static IDictionary<Type, DependencyBuilder> dependency_builders;
        }

        [Subject(typeof(BasicDependencyBuilders))]
        public class when_getting_the_dependency_builder_for_a_type_and_it_has_the_builder : concern
        {
            Establish c = () =>
            {
                the_builder_that_can_create_connections = an<DependencyBuilder>();
                dependency_builders.Add(typeof(IDbConnection), the_builder_that_can_create_connections);
            };

            Because b = () =>
                result = sut.get_the_builder_to_build<IDbConnection>();

            It should_return_the_builder_to_the_caller = () =>
                result.ShouldEqual(the_builder_that_can_create_connections);

            static DependencyBuilder result;
            static DependencyBuilder the_builder_that_can_create_connections;
        }

        [Subject(typeof(BasicDependencyBuilders))]
        public class when_attempting_to_get_the_dependency_builder_for_a_type_and_it_does_not_have_the_builder : concern
        {
            Because b = () =>
                catch_exception(() => sut.get_the_builder_to_build<IDbConnection>());

            It should_throw_a_builder_not_registered_exception_with_the_correct_details = () =>
            {
                exception_thrown_by_the_sut.ShouldBeAn<DependencyBuilderNotRegisteredException>()
                    .type_that_has_no_builder.ShouldEqual(typeof(IDbConnection));
            };

        }
    }
}