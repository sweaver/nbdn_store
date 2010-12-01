using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RequestFactory
    {
        void create_from(HttpContext the_context);
    }
}