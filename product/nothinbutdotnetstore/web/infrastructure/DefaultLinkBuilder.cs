using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface LinkBuilder
    {
        void include<Item>(Item payload_value, string key);
    }

    public class DefaultLinkBuilder : LinkBuilder
    {
        public const string link_format = "{0}.store?{1}";
        IDictionary<string, object> values;
        PayloadTokensMapper payload_tokens_mapper;
        TokenAppenderFactory token_appender_factory;

        public Type command_to_run { get; private set; }

        public DefaultLinkBuilder() : this(new Dictionary<string, object>(),
                                           new DefaultPayloadTokensMapper(), new ItemBoundTokenAppenderFactory())
        {
        }

        public DefaultLinkBuilder(IDictionary<string, object> values, PayloadTokensMapper payload_tokens_mapper,
                                  TokenAppenderFactory token_appender_factory)
        {
            this.values = values;
            this.payload_tokens_mapper = payload_tokens_mapper;
            this.token_appender_factory = token_appender_factory;
        }

        public void include<Item>(Item payload_value, string key)
        {
            values.Add(key, payload_value);
        }

        public static implicit operator string(DefaultLinkBuilder builder)
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
            return token_appender_factory.create_appender(item, this);
        }

        public DefaultLinkBuilder to_target<Command>() where Command : ApplicationCommand
        {
            this.command_to_run = typeof(Command);
            return this;
        }
    }
}