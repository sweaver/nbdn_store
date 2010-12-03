namespace nothinbutdotnetstore.web.infrastructure
{
    public class Link
    {
        public static DefaultLinkBuilder to_run<CommandToRun>() where CommandToRun : ApplicationCommand
        {
            return new DefaultLinkBuilder().to_target<CommandToRun>();
        }
    }
}