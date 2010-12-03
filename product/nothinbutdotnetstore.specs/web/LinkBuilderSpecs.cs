using System;
using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.repositories.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class LinkBuilderSpecs
    {
        public abstract class concern : Observes<DefaultLinkBuilder>
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

        public class when_specifying_a_command_to_run : concern
        {
            Establish c = () =>
            {
                key = "blah";
                my_model = new MyModel {name = "bsdfsdf"};
            };

            Because b = () =>
                result = sut.to_target<MyCommand>();

            It should_store_the_type_of_the_command_to_be_run = () =>
                sut.command_to_run.ShouldEqual(typeof(MyCommand));

            It should_return_the_builder_to_continue_url_building = () =>
                result.ShouldEqual(sut);

            static string key;
            static MyModel my_model;
            static DefaultLinkBuilder result;
        }

        [Subject(typeof(DefaultLinkBuilder))]
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

        public class concern_for_link_builder_with_a_targeted_command : concern
        {
        }

        [Subject(typeof(DefaultLinkBuilder))]
        public class when_implicitly_converted_to_a_string_and_it_has_no_payload_values :
            concern_for_link_builder_with_a_targeted_command
        {
            Because b = () =>
            {
                sut.to_target<MyCommand>();
                result = sut;
            };

            It should_return_the_name_of_the_command_suffixed_with_store = () =>
                result.ShouldBeEqualIgnoringCase(DefaultLinkBuilder.link_format.format_using(
                    typeof(MyCommand).Name, ""));

            static
                string result;
        }

        [Subject(typeof(DefaultLinkBuilder))]
        public class when_implicitly_converted_to_a_string_and_it_has_payload_values :
            concern_for_link_builder_with_a_targeted_command
        {
            Establish c = () =>
            {
                mapped_tokens = "this is the result";

                payload_tokens_mapper.Stub(
                    x => x.map(Arg<IEnumerable<KeyValuePair<string, object>>>.Is.Equal(payload_values))).Return
                    (mapped_tokens);
            };

            Because b = () =>
            {
                sut.to_target<MyCommand>();
                result = sut.ToString();
            };

            It should_return_the_name_of_the_command_suffixed_with_store_and_the_transformed_payload_values
                = () =>
                    result.ShouldEqual(DefaultLinkBuilder.link_format.format_using(typeof(MyCommand).Name,
                                                                                   mapped_tokens));

            static
                string result;

            static string mapped_tokens;
        }

        public class when_a_tokenizer_is_requested_for_an_item : concern
        {
            Establish c = () =>
            {
                the_person = new Person();
                token_appender_factory = the_dependency<TokenAppenderFactory>();
                token_appender = an<TokenAppender<Person>>();

                token_appender_factory.Stub(x => x.create_appender(Arg<Person>.Is.Equal(the_person), Arg<DefaultLinkBuilder>.Is.NotNull)).
                    Return(token_appender);
            };

            Because b = () =>
                result = sut.tokenize_with(the_person);

            It should_return_a_token_appender_that_can_work_with_the_type = () =>
                result.ShouldEqual(token_appender);

            static TokenAppender<Person> result;
            static Person the_person;
            static TokenAppenderFactory token_appender_factory;
            static TokenAppender<Person> token_appender;
        }

        public class Person
        {
        }

        public class acceptance
        {
            public class concern : Observes<DefaultLinkBuilder>
            {
                Establish c = () =>
                {
                    create_sut_using(() => new DefaultLinkBuilder());
                };
            }

            [Subject(typeof(DefaultLinkBuilder))]
            public class when_building_links_with_real_dependencies : concern
            {
                Because b = () =>
                {
                    sut.to_target<MyCommand>();
                    var model = new MyModel {name = "this_is_a_name"};

                    sut.include(23, "hello");
                    sut.include(24, "again");
                    sut.tokenize_with(model).include(x => x.name);

                    result = sut;
                };

                It should_create_the_correct_links = () =>
                    result.Contains("MyCommand.store?hello=23&again=24&name=this_is_a_name");

                static string result;
            }

            public class when_building_links_with_real_dependencies_and_explicitly_calling_to_string : concern
            {
                Because b = () =>
                {
                    var model = new MyModel {name = "this_is_a_name"};

                    result = sut.to_target<MyCommand>()
                       .tokenize_with(model).include(x => x.name).ToString();
                };

                It should_create_the_correct_links = () =>
                    result.Contains("MyCommand.store?name=this_is_a_name");

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