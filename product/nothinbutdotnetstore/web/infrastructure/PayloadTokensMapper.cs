using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface PayloadTokensMapper
    {
        string map(IEnumerable<KeyValuePair<string,object>> tokens);
    }
}