using System;
using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class LinkBuilderSpecs
    {
        public abstract class concern : Observes<LinkBuilder<MyCommand>>
        {
            Establish c = () =>
            {
                payload_values = new Dictionary<string, object>();
                provide_a_basic_sut_constructor_argument(payload_values);
                payload_tokens_mapper = the_dependency<PayloadTokensMapper>();
            };

            protected static IDictionary<string, object> payload_values;
            protected static PayloadTokensMapper payload_tokens_mapper;
        }

        [Subject(typeof(LinkBuilder<>))]
        public class when_adding_a_basic_key_value_pair : concern
        {
            Establish c = () =>
            {
                key = "blah";
                my_model = new MyModel {name = "bsdfsdf"};
            };

            Because b = () =>
                sut.include(my_model.name, key);

            It should_store_the_key_value_pair_for_later_use_in_url_building = () =>
                payload_values[key].ShouldEqual(my_model.name);

            static string key;
            static MyModel my_model;
        }

        [Subject(typeof(LinkBuilder<>))]
        public class when_implicitly_converted_to_a_string_and_it_has_no_payload_values : concern
        {
            Because b = () =>
                result = sut;

            It should_return_the_name_of_the_command_suffixed_with_store = () =>
                result.ShouldBeEqualIgnoringCase(LinkBuilder<MyCommand>.link_format.format_using(
                    typeof(MyCommand).Name, ""));

            static
                string result;
        }

        [Subject(typeof(LinkBuilder<>))]
        public class when_implicitly_converted_to_a_string_and_it_has_payload_values : concern
        {
            Establish c = () =>
            {
                mapped_tokens = "this is the result";

                payload_tokens_mapper.Stub(
                    x => x.map(Arg<IEnumerable<KeyValuePair<string, object>>>.Is.Equal(payload_values))).Return
                    (mapped_tokens);
            };

            Because b = () =>
                result = sut.ToString();

            It should_return_the_name_of_the_command_suffixed_with_store_and_the_transformed_payload_values
                = () =>
                    result.ShouldEqual(LinkBuilder<MyCommand>.link_format.format_using(typeof(MyCommand).Name,
                                                                                       mapped_tokens));

            static
                string result;

            static string mapped_tokens;
        }

        public class acceptance
        {
            public class concern : Observes<LinkBuilder<MyCommand>>
            {
                Establish c = () =>
                {
                    create_sut_using(() => new LinkBuilder<MyCommand>(
                        new Dictionary<string, object>(),
                        new DefaultPayloadTokensMapper()));
                };
            }

            [Subject(typeof(LinkBuilder<>))]
            public class when_building_links_with_real_dependencies : concern
            {
                Because b = () =>
                {
                    sut.include(23, "hello");
                    sut.include(24, "again");
                    result = sut;
                };

                It should_create_the_correct_links = () =>
                    result.Contains("MyCommand.store?hello=23&again=24");

                static string result;
 
  

            }
        }

        class MyModel
        {
            public string name { get; set; }
        }

        public class MyCommand : ApplicationCommand
        {
            public void process(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}