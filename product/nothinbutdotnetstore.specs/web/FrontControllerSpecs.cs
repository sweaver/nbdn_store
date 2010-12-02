using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<FrontController,
                                            DefaultFrontController>
        {
        }

        [Subject(typeof(DefaultFrontController))]
        public class when_processing_an_request : concern
        {
            Establish c = () =>
            {
                command_registry = the_dependency<CommandRegistry>();
                request = an<Request>();
                command_that_can_process_request = an<RequestCommand>();

                command_registry.Stub(x => x.get_command_that_can_process(request)).Return(
                    command_that_can_process_request);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_command_that_can_process_the_request_to_process_the_request = () =>
                command_that_can_process_request.received(x => x.process(request));

            static RequestCommand command_that_can_process_request;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}