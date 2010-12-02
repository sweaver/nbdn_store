using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class LinkBuilder<CommandToRun> where CommandToRun : ApplicationCommand
    {
        public const string link_format = "{0}.store?{1}";
        IDictionary<string, object> values;
        PayloadTokensMapper payload_tokens_mapper;

        public LinkBuilder(IDictionary<string, object> values, PayloadTokensMapper payload_tokens_mapper)
        {
            this.values = values;
            this.payload_tokens_mapper = payload_tokens_mapper;
        }

        public void include<ValueType>(ValueType payload_value, string key)
        {
            values.Add(key, payload_value);
        }

        public static implicit operator string(LinkBuilder<CommandToRun> builder)
        {
            return builder.ToString();
        }

        public override string ToString()
        {
            return string.Format(link_format,
                                 typeof(CommandToRun).Name,
                                 payload_tokens_mapper.map(values));
        }
    }
}