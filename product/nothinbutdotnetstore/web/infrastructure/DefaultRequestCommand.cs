namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultRequestCommand : RequestCommand
    {
        ApplicationCommand application_command;
        RequestSpecification request_specification;

        public DefaultRequestCommand(RequestSpecification request_specification, ApplicationCommand application_command)
        {
            this.request_specification = request_specification;
            this.application_command = application_command;
        }

        public bool can_process(Request the_request)
        {
            return request_specification(the_request);
        }

        public void process(Request request)
        {
            application_command.process(request);
        }
    }
}