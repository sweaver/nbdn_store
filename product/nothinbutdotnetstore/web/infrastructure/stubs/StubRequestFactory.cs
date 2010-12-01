using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext the_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
        }
    }
}