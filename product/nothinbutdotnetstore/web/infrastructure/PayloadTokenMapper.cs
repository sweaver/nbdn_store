using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface PayloadTokenMapper
    {
        string map(KeyValuePair<string,object> token);
    }
}