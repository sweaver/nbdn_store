 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.specs.web
{   
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
        
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determinining_if_it_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<RequestSpecification>(x => true);
            };

            Because b = () =>
                result = sut.can_process(request);

            It should_make_the_determination_by_using_its_request_specification = () =>
                result.ShouldBeTrue();


            static bool result;
            static Request request;
        }


        [Subject(typeof(DefaultRequestCommand))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                application_behaviour = the_dependency<ApplicationCommand>();
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<RequestSpecification>(x => true);
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_the_processing_to_its_application_specific_command = () =>
                application_behaviour.received(x => x.process(request));


            static Request request;
            static ApplicationCommand application_behaviour;
        }
    }
}
