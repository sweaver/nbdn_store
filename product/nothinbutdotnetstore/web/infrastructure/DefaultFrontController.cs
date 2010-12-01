namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry command_registry;

        public DefaultFrontController(CommandRegistry registry)
        {
            this.command_registry = registry;
        }

        public void process(Request request)
        {
            this.command_registry.get_command_that_can_process(request).process(request);
        }
    }
}