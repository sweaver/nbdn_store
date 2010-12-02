using System;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class Link
    {
        public static LinkBuilder<CommandToRun> to_run<CommandToRun>()   where CommandToRun : ApplicationCommand
        {
            throw new NotImplementedException();
        }

        public static LinkBuilder<>
    }
}