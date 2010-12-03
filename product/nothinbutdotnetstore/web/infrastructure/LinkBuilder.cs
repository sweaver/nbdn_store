using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class LinkBuilder
    {
        public const string link_format = "{0}.store?{1}";
        IDictionary<string, object> values;
        PayloadTokensMapper payload_tokens_mapper;
        public Type command_to_run { get; private set; }

        public LinkBuilder(IDictionary<string, object> values, PayloadTokensMapper payload_tokens_mapper)
        {
            this.values = values;
            this.payload_tokens_mapper = payload_tokens_mapper;
        }


        public void include<ValueType>(ValueType payload_value, string key)
        {
            values.Add(key, payload_value);
        }

        public static implicit operator string(LinkBuilder builder)
        {
            return builder.ToString();
        }

        public override string ToString()
        {
            return string.Format(link_format,
                                 command_to_run.Name,
                                 payload_tokens_mapper.map(values));
        }

        public TokenAppender<Item> tokenize_with<Item>(Item item)
        {
            throw new NotImplementedException();
        }

        public LinkBuilder to_run<Command>() where Command : ApplicationCommand
        {
            this.command_to_run = typeof(Command);
            return this;
        }
    }
}