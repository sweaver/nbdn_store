 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.specs.web
{   
    public class RawRequestHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            RawRequestHandler>
        {
        
        }

        [Subject(typeof(RawRequestHandler))]
        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                request_factory = the_dependency<RequestFactory>();
                the_context = ObjectMother.create_http_context();
            };

            Because b = () =>
                sut.ProcessRequest(the_context);

                
            It should_use_the_request_factory_to_create_a_request_from_the_http_context = () =>
                request_factory.received(x => x.create_from(the_context));

            static RequestFactory request_factory;
            static HttpContext the_context;
        }
    }
}
