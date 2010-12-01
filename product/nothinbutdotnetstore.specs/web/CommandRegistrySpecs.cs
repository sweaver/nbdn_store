 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{   
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<CommandRegistry,
                                            DefaultCommandRegistry>
        {
        
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_getting_a_command_for_a_request_and_it_has_the_command : concern
        {

            Establish c = () =>
            {
                the_request = an<Request>();
                all_commands = Enumerable.Range(1, 100).Select(x => an<RequestCommand>()).ToList();
                the_command_that_can_process_the_request = an<RequestCommand>();
                all_commands.Add(the_command_that_can_process_the_request);
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);

                the_command_that_can_process_the_request.Stub(x => x.can_process(the_request)).Return(true);

            };

            Because b = () =>
                result = sut.get_command_that_can_process(the_request);

            It should_return_the_command_that_can_process_the_request = () =>
                result.ShouldEqual(the_command_that_can_process_the_request);

            static RequestCommand result;
            static RequestCommand the_command_that_can_process_the_request;
            static Request the_request;
            static IList<RequestCommand> all_commands;
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_getting_a_command_for_a_request_and_it_does_not_have_the_command : concern
        {

            Establish c = () =>
            {
                the_request = an<Request>();
                all_commands = Enumerable.Range(1, 100).Select(x => an<RequestCommand>()).ToList();
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);
            };

            Because b = () =>
                result = sut.get_command_that_can_process(the_request);

            It should_return_a_missing_command = () =>
                result.ShouldBeAn<MissingRequestCommand>();

            static RequestCommand result;
            static Request the_request;
            static IList<RequestCommand> all_commands;
        }
    }
}
