 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.specs.web
{   
    public class TokenAppenderFactorySpecs
    {
        public abstract class concern : Observes<TokenAppenderFactory,
                                            ItemBoundTokenAppenderFactory>
        {
        
        }

        [Subject(typeof(ItemBoundTokenAppenderFactory))]
        public class when_creating_a_token_appender_bound_to_an_item : concern
        {

            Establish c = () =>
            {
                the_item = new TheItem();
                builder = new DefaultLinkBuilder();
            };

            Because b = () =>
                result = sut.create_appender(the_item, builder);

            It should_return_a_token_appender_that_has_access_to_the_item_and_the_original_link_builder = () =>
            {
                var item_bound_token_appender = result.ShouldBeAn<ItemBoundTokenAppender<TheItem>>();
                item_bound_token_appender.item_with_values.ShouldEqual(the_item);
                item_bound_token_appender.builder.ShouldEqual(builder);
            };

            static TokenAppender<TheItem> result;
            static DefaultLinkBuilder builder;
            static TheItem the_item;
        }
    public class TheItem
    {
    }
    }

}
