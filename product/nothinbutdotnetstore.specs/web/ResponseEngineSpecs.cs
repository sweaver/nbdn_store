 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{   
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            DefaultResponseEngine>
        {
        
        }

        [Subject(typeof(DefaultResponseEngine))]
        public class when_displaying_a_view_model : concern
        {
            Establish c = () =>
            {
                view_registry = the_dependency<ResponseViewRegistry>();
                view_that_can_display_the_model = an<ResponseView>();
                view_model = new OurViewModel();
                view_registry.Stub(x => x.get_view_that_can_display<OurViewModel>()).Return(
                    view_that_can_display_the_model);

            };

            Because b = () =>
                sut.display(view_model);


            It should_tell_the_view_to_render = () =>
                view_that_can_display_the_model.received(x => x.render(view_model));

  


            static ResponseViewRegistry view_registry;
            static OurViewModel view_model;
            static ResponseView view_that_can_display_the_model;
        }
    }

    class OurViewModel
    {
    }
}
