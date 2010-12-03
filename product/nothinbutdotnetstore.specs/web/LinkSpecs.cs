using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.specs.web
{
    public class LinkSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Link))]
        public class when_requesting_to_build_a_link : concern
        {
            Because b = () =>
                result = Link.to_run<MyCommand>();

            It should_return_the_correct_link_aggregator = () =>
                result.ShouldNotBeNull();

            static LinkBuilder result;
        }

        class MyCommand : ApplicationCommand
        {
            public void process(Request request)
            {
            }
        }
    }
}