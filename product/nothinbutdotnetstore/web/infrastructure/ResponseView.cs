namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ResponseView
    {
        void render<ViewModel>(ViewModel view_model);
    }
}