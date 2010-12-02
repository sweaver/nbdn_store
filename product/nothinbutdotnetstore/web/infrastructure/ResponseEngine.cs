namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ResponseEngine
    {
        void display<ViewModel>(ViewModel item_to_display);
    }
}