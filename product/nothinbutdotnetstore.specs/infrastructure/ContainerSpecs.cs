 
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Container))]
        public class when_accessing_the_container_gateway : concern
        {
            Establish c = () =>
            {
                the_underlying_container = an<DependencyContainer>();
                ContainerResolver resolver = () => the_underlying_container;
                change(() => Container.resolver).to(resolver);
            };

            Because b = () =>
                result = Container.resolve;

            It should_return_the_facade_to_the_underlying_container_framework = () =>
                result.ShouldEqual(the_underlying_container);

            static DependencyContainer result;
            static DependencyContainer the_underlying_container;
        }
    }
}
