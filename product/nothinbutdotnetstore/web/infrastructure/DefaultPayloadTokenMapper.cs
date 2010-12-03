using System.Collections.Generic;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultPayloadTokenMapper : PayloadTokenMapper
    {
        Encode encode;

        public DefaultPayloadTokenMapper() : this(x => HttpUtility.UrlEncode(x.ToString()))
        {
        }

        public DefaultPayloadTokenMapper(Encode encode)
        {
            this.encode = encode;
        }

        public string map(KeyValuePair<string, object> token)
        {
            return string.Format("{0}={1}", encode(token.Key), encode(token.Value));
        }
    }
}