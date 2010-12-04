 using System;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
{   
    public class DependencyBuilderSpecs
    {
        public abstract class concern : Observes<DependencyBuilder,
                                            BasicDependencyBuilder>

        {
        
        }

        [Subject(typeof(BasicDependencyBuilder))]
        public class when_creating_a_dependency_for_a_type_that_has_dependencies : concern
        {
            Establish c = () =>
            {
                the_connection = new SqlConnection();
                Func<object> factory = () => the_connection;
                provide_a_basic_sut_constructor_argument(factory);

            };

            Because b = () =>
                result = sut.build();


            It should_return_the_dependency_created_by_the_factory = () =>
                result.ShouldEqual(the_connection);

            static object result;
            static SqlConnection the_connection;
        }
    }
}
