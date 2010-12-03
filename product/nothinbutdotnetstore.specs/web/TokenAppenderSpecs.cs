 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.specs.web
{   
    public class TokenAppenderSpecs
    {
        public abstract class concern : Observes<TokenAppender<SomeViewModel>,
                                            ItemBoundTokenAppender<SomeViewModel>>
        {
        
        }

        [Subject(typeof(ItemBoundTokenAppender<>))]
        public class when_including_a_property_from_an_item : concern
        {
            Establish c = () =>
            {
                the_model = new SomeViewModel {name = "class2010"};
                link_builder = the_dependency<LinkBuilder>();
                provide_a_basic_sut_constructor_argument(the_model);
            };

            Because b = () =>
                result=sut.include(x => x.name);


            It should_tell_the_link_builder_to_include_the_value_of_the_property_using_its_property_name_as_the_key =
                () =>
                    link_builder.received(x => x.include(the_model.name, "name"));

            It should_return_the_link_builder_to_continue_link_manipulation = () =>
                result.ShouldEqual(link_builder);

  


  

            static SomeViewModel the_model;
            static LinkBuilder link_builder;
            static LinkBuilder result;
        }
    }
    public class SomeViewModel
    {
        public string name { get; set; }
    }

}
