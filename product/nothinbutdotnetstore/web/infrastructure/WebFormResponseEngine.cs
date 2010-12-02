using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class WebFormResponseEngine : ResponseEngine
    {
        ViewFactory view_factory;
        CurrentContextResolver current_context_resolver;

        public WebFormResponseEngine():this(new WebFormViewFactory(),() => HttpContext.Current)
        {
        }

        public WebFormResponseEngine(ViewFactory view_factory, CurrentContextResolver current_context_resolver)
        {
            this.view_factory = view_factory;
            this.current_context_resolver = current_context_resolver;
        }

        public void display<ViewModel>(ViewModel item_to_display)
        {
            view_factory.create_for(item_to_display).ProcessRequest(current_context_resolver());
        }
    }
}