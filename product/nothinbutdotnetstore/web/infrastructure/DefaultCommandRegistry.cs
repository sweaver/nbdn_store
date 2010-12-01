using System;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        public RequestCommand get_command_that_can_process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}