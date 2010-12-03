using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RawRequestHandler : IHttpHandler
    {
        RequestFactory request_factory;
        FrontController front_controller;

        public RawRequestHandler()
        {
        }

        public RawRequestHandler(RequestFactory request_factory, FrontController front_controller)
        {
            this.request_factory = request_factory;
            this.front_controller = front_controller;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}