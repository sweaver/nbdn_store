using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        private IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry():this(new StubRequestCommands())
        {
        }

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_command_that_can_process(Request request)
        {
            return this.all_commands.FirstOrDefault(x => x.can_process(request)) ??
                new MissingRequestCommand();
        }
    }
}