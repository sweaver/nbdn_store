using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure;

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
            };

            protected static IDictionary<string, object> payload_values;
        }

        [Subject(typeof(LinkBuilder<>))]
        public class when_adding_a_key_value_pair : concern
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
                result.ShouldBeEqualIgnoringCase(LinkBuilder<MyCommand>.link_format.format_using(typeof(MyCommand).Name));

            static
                string result;
        }


        [Subject(typeof(LinkBuilder<>))]
        public class when_implicitly_converted_to_a_string_and_it_has_payload_values : concern
        {
            Establish c = () =>
            {
                payload_values.Add("one", 1);
                payload_values.Add("two", 2);
                payload_values.Add("three", 3);
                payload_values.Add("today", DateTime.Now);
            };

            Because b = () =>
                result = sut.ToString();

            private It should_return_the_name_of_the_command_suffixed_with_store_and_correct_formatted_payload_values =
                () =>
                result.ShouldEqual(string.Format("{0}.store?{1}",typeof(MyCommand).Name,string_of_values(payload_values)));

            static
                string result;
        }
        
        private static string string_of_values(IDictionary<string, object> payloadValues)
            {
                StringBuilder returnValue = new StringBuilder(500);
                foreach(KeyValuePair<string,object> keyvalue in payloadValues)
                {
                    returnValue.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(keyvalue.Key), HttpUtility.UrlEncode(keyvalue.Value.ToString()));
                }

                return returnValue.ToString().Substring(1);
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