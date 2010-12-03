using System.Web;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext the_context)
        {
            return new StubRequest(the_context.Request.RawUrl);
        }

        class StubRequest : Request
        {
            string raw_url;

            public StubRequest(string raw_url)
            {
                this.raw_url = raw_url;
            }

            public InputModel map<InputModel>()
            {
                object department = new Department {name = "this is the sub department"};
                return (InputModel) department;
            }

            public string full_command
            {
                get { return raw_url; }
            }
        }
    }
}