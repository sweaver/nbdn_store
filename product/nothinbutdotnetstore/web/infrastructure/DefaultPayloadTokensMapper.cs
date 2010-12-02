using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultPayloadTokensMapper : PayloadTokensMapper
    {
        PayloadTokenMapper payload_token_mapper;

        public DefaultPayloadTokensMapper():this(new DefaultPayloadTokenMapper())
        {
        }

        public DefaultPayloadTokensMapper(PayloadTokenMapper payload_token_mapper)
        {
            this.payload_token_mapper = payload_token_mapper;
        }

        public string map(IEnumerable<KeyValuePair<string, object>> tokens)
        {
            return string.Join("&", tokens.Select(payload_token_mapper.map).ToArray());
        }
    }
}