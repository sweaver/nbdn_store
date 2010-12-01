using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RawRequestHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}