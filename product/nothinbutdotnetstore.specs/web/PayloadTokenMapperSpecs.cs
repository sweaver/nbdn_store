 using System.Collections.Generic;
 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;
 using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.web
{   
    public class PayloadTokenMapperSpecs
    {
        public abstract class concern : Observes<PayloadTokenMapper,
                                            DefaultPayloadTokenMapper>
        {
        
        }

        [Subject(typeof(DefaultPayloadTokenMapper))]
        public class when_mapping_from_a_key_value_pair_to_a_string : concern
        {
            Establish c = () =>
            {
                key = "the_key";
                value = 23;

                Encode encode = x =>
                {
                    enconding_was_performed = true;
                    return x.ToString();
                };
                provide_a_basic_sut_constructor_argument(encode);

            };
            Because b = () =>
                result = sut.map(new KeyValuePair<string, object>(key, value));

            It should_correctly_url_encode_and_join_the_key_and_the_value = () =>
            {
                enconding_was_performed.ShouldBeTrue();
                result.ShouldEqual("{0}={1}".format_using(key, value.ToString()));
            };

            static string result;
            static string key;
            static object value;
            static bool enconding_was_performed;
        }
    }
}
