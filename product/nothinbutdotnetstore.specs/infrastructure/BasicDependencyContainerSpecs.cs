using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class BasicDependencyContainerSpecs
    {
        public abstract class concern : Observes<DependencyContainer,
                                            BasicDependencyContainer>
        {
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_resolving_an_implementation_of_a_dependency : concern
        {
            Establish c = () =>
            {
                the_sql_connection = new SqlConnection();
                dependency_builder = an<DependencyBuilder>();
                builder_registry = the_dependency<DependencyBuilders>();

                builder_registry.Stub(x => x.get_the_builder_to_build<IDbConnection>()).Return(dependency_builder);
                dependency_builder.Stub(x => x.build()).Return(the_sql_connection);
            };

            Because b = () =>
                result = sut.an<IDbConnection>();

            It should_return_the_dependency_created_by_the_builder_for_that_dependency = () =>
                result.ShouldEqual(the_sql_connection);

            static IDbConnection result;
            static SqlConnection the_sql_connection;
            static DependencyBuilder dependency_builder;
            static DependencyBuilders builder_registry;
        }
    }
}