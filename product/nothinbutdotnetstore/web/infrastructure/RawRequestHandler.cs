using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RawRequestHandler : IHttpHandler
    {
        private RequestFactory requestFactory;

        public RawRequestHandler(RequestFactory requestFactory)
        {
            this.requestFactory = requestFactory;
        }

        public void ProcessRequest(HttpContext context)
        {
            requestFactory.create_from(context);
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}