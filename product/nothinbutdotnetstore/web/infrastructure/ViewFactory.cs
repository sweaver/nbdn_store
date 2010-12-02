namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ViewFactory
    {
        WebView<ViewModel> create_for<ViewModel>(ViewModel model);
    }
}