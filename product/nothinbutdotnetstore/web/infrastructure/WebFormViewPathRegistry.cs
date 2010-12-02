namespace nothinbutdotnetstore.web.infrastructure
{
    public interface WebFormViewPathRegistry
    {
        string get_path_to_view_that_can_display<ViewModel>();
    }
}