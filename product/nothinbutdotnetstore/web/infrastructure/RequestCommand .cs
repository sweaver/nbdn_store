namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RequestCommand 
    {
        void process(Request request);
    }
}