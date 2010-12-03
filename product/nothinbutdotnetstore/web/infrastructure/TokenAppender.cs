using System;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface TokenAppender<Item>
    {
        LinkBuilder include<PropertyType>(Expression<Func<Item, PropertyType>> property_accessor);
    }
}