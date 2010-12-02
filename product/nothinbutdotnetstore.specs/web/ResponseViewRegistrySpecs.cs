 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.specs.web
{   
    public class ResponseViewRegistrySpecs
    {
        public abstract class concern : Observes<ResponseViewRegistry,
                                            DefaultResponseViewRegistry>
        {
        
        }

        [Subject(typeof(DefaultResponseViewRegistry))]
        public class when_ : concern
        {
        
            It first_observation = () =>        
                
        }
    }
}
