using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RequestFactory
    {
        object create_from(HttpContext the_context);
    }
}