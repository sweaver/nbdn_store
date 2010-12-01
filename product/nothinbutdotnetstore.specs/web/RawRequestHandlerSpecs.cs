 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

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
                front_controller = the_dependency<FrontController>();
                request_factory = the_dependency<RequestFactory>();
                the_context = ObjectMother.create_http_context();
                request = an<Request>();

                request_factory.Stub(x => x.create_from(the_context)).Return(request);
            };

            Because b = () =>
                sut.ProcessRequest(the_context);

                
            It should_tell_the_front_controller_to_process_the_request = () =>
                front_controller.received(x => x.process(request));
  

            static RequestFactory request_factory;
            static HttpContext the_context;
            static FrontController front_controller;
            static Request request;
        }
    }
}
