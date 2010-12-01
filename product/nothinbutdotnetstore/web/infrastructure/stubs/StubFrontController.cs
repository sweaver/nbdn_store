using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubFrontController : FrontController
    {
        public void process(Request request)
        {
            HttpContext.Current.Response.Write("Hello I am the front controller");
        }
    }
}