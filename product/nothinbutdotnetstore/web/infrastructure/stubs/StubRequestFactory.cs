using System.Web;
using nothinbutdotnetstore.model;

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
            public InputModel map<InputModel>()
            {
                object department = new Department();
                return (InputModel) department;
            }
        }
    }
}