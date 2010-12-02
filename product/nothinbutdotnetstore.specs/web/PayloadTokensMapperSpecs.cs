 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{   
    public class PayloadTokensMapperSpecs
    {
        public abstract class concern : Observes<PayloadTokensMapper    ,
                                            DefaultPayloadTokensMapper>
        {
        
        }

        public class FakeTokenizer : PayloadTokenMapper
        {
            Func<KeyValuePair<string, object>,string> evaluate_using;

            public FakeTokenizer(Func<KeyValuePair<string, object>,string> evaluate_using)
            {
                this.evaluate_using = evaluate_using;
            }

            public string map(KeyValuePair<string, object> token)
            {
                return evaluate_using(token);
            }
        }

        [Subject(typeof(DefaultPayloadTokensMapper))]
        public class when_mapping_a_sequence_of_key_value_pairs_to_a_string : concern
        {
            Establish c = () =>
            {
                set_of_tokens = new Dictionary<string, object>();
                set_of_tokens.Add("1", 1);
                set_of_tokens.Add("2", 2);
                set_of_tokens.Add("3", 3);

                payload_token_mapper = new FakeTokenizer(x => x.Value.ToString());
                provide_a_basic_sut_constructor_argument(payload_token_mapper);
            };

            Because b = () =>
                result = sut.map(set_of_tokens);


            It should_return_a_single_string_formed_by_mapping_each_element_using_a_payload_token_mapper = () =>
                result.ShouldEqual("1&2&3");

            static string result;
            static IDictionary<string, object> set_of_tokens;
            static PayloadTokenMapper payload_token_mapper;
        }
    }
}
