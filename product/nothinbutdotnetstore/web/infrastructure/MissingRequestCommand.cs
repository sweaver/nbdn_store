using System;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class MissingRequestCommand : RequestCommand
    {
        public void process(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(Request the_request)
        {
            throw new NotImplementedException();
        }
    }
}