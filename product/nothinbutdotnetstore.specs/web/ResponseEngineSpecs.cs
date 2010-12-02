using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            WebFormResponseEngine>
        {
        }

        [Subject(typeof(WebFormResponseEngine))]
        public class when_displaying_a_view_model : concern
        {
            Establish c = () =>
            {
                current_request = ObjectMother.create_http_context();
                view_factory = the_dependency<ViewFactory>();
                CurrentContextResolver resolver = () => current_request;
                provide_a_basic_sut_constructor_argument(current_request);
                provide_a_basic_sut_constructor_argument(resolver);
                view_that_can_display_the_model = an<WebView<OurViewModel>>();
                view_model = new OurViewModel();

                view_factory.Stub(x => x.create_for(view_model)).Return(view_that_can_display_the_model);
            };

            Because b = () =>
                sut.display(view_model);

            It should_tell_the_view_to_render = () =>
                view_that_can_display_the_model.received(x => x.ProcessRequest(current_request));

            static ViewFactory view_factory;
            static OurViewModel view_model;
            static WebView<OurViewModel> view_that_can_display_the_model;
            static HttpContext current_request;
        }
    }

    public class OurViewModel
    {
    }
}