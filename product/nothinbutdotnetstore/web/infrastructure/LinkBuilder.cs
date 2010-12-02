using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class LinkBuilder<CommandToRun> where CommandToRun : ApplicationCommand
    {
        public const string link_format = "{0}.store";
        IDictionary<string, object> values;

        public LinkBuilder(IDictionary<string, object> values)
        {
            this.values = values;
        }

        public void include<ValueType>(ValueType payload_value, string key)
        {
            values.Add(key, payload_value);
        }

        public static implicit operator string(LinkBuilder<CommandToRun> builder)
        {
            return string.Format(link_format, typeof(CommandToRun).Name);
        }
    }
}