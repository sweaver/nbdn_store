using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class WebFormViewFactorySpecs
    {
        public abstract class concern : Observes<ViewFactory,
                                            WebFormViewFactory>
        {
        }

        [Subject(typeof(WebFormViewFactory))]
        public class when_creating_a_view_that_can_display_a_model : concern
        {
            Establish c = () =>
            {
                web_form_view_path_registry = the_dependency<WebFormViewPathRegistry>();
                the_view = an<WebView<OurViewModel>>();
                the_actual_path = "blah.aspx";

                page_factory = (path, type) =>
                {
                    path_requested = path;
                    type_requested = type;
                    return the_view;
                };
                provide_a_basic_sut_constructor_argument(page_factory);

                our_model = new OurViewModel();

                web_form_view_path_registry.Stub(x => x.get_path_to_view_that_can_display<OurViewModel>()).Return(
                    the_actual_path);
            };

            Because b = () =>
                result = sut.create_for(our_model);

            It should_dispatch_correctly_to_the_page_factory = () =>
            {
                path_requested.ShouldEqual(the_actual_path);
                type_requested.ShouldEqual(typeof(WebView<OurViewModel>));
            };

            It should_set_the_view_model_on_the_view = () =>
                result.model.ShouldEqual(our_model);

            static WebView<OurViewModel> result;
            static WebView<OurViewModel> the_view;
            static OurViewModel our_model;
            static WebFormViewPathRegistry web_form_view_path_registry;
            static PageFactory page_factory;
            static string path_requested;
            static Type type_requested;
            static string the_actual_path;
        }
    }
}