using System.Collections.Generic;
using System.Text;
using System.Web;

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

        public override string ToString() {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(typeof (CommandToRun).Name);
            sb.Append(".store?");
            StringBuilder returnValue = new StringBuilder(500);
            foreach (KeyValuePair<string, object> keyvalue in values) {
                returnValue.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(keyvalue.Key), HttpUtility.UrlEncode(keyvalue.Value.ToString()));
            }

            return sb + returnValue.ToString().Substring(1);
        }

    }
}