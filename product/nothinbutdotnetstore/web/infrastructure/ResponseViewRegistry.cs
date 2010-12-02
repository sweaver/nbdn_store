namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ResponseViewRegistry
    {
        ResponseView get_view_that_can_display<ViewModel>();
    }
}