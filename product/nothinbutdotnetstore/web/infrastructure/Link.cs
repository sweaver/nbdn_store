using System;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class Link
    {
        public static LinkBuilder to_run<CommandToRun>() where CommandToRun : ApplicationCommand
        {
//            return new LinkBuilder().to_run<CommandToRun>();
            throw new NotImplementedException();
        }
    }
}