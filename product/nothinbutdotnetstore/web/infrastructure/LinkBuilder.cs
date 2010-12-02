namespace nothinbutdotnetstore.web.infrastructure
{
    public class LinkBuilder
    {
        public static LinkAgregator<ViewToRun> to_run<ViewToRun>()         {
            return new LinkAgregator<ViewToRun>();
        }
    }
}