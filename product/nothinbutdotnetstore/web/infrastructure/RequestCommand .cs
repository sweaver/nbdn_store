namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RequestCommand 
    {
        void process(Request request);
        bool can_process(Request the_request);
    }
}