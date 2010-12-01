using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RawRequestHandler : IHttpHandler
    {
        RequestFactory request_factory;

        public RawRequestHandler(RequestFactory request_factory)
        {
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            request_factory.create_from(context);
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}