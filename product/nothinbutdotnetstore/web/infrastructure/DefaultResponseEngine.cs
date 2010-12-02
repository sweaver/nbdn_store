namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultResponseEngine : ResponseEngine
    {
        ResponseViewRegistry response_view_registry;

        public DefaultResponseEngine(ResponseViewRegistry response_view_registry)
        {
            this.response_view_registry = response_view_registry;
        }

        public void display<ViewModel>(ViewModel item_to_display)
        {
            response_view_registry.get_view_that_can_display<ViewModel>().render(item_to_display);
        }
    }
}