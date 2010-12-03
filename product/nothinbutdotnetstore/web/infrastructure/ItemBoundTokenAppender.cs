using System;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class ItemBoundTokenAppender<Item> : TokenAppender<Item>
    {
        public Item item_with_values { get; private set; }
        public LinkBuilder builder { get; private set; }

        public ItemBoundTokenAppender(Item item_with_values, LinkBuilder builder)
        {
            this.item_with_values = item_with_values;
            this.builder = builder;
        }

        public LinkBuilder include<PropertyType>(Expression<Func<Item, PropertyType>> property_accessor)
        {
            var value = property_accessor.Compile()(item_with_values);
            builder.include(value, parse_for_property_name(property_accessor));
            return builder;
        }

        string parse_for_property_name<PropertyType>(Expression<Func<Item, PropertyType>> property_accessor)
        {
            var member_expression = (MemberExpression) property_accessor.Body;
            return member_expression.Member.Name;
        }
    }
}