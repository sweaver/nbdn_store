using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnet.concepts.concepts
{
    public class MessingWithExpressionTrees
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Expression<>))]
        public class getting_an_idea_of_what_can_be_done_with_expression_trees : concern
        {
            It should_be_able_to_use_an_expression_to_get_the_name_and_value_of_a_property = () =>
            {
                var person = new Person {name = "jp"};

                Expression<Func<Person, string>> name_accessor = x => x.name;

                var property_name = name_accessor.Body.downcast_to<MemberExpression>().Member.Name;
                var property_value = name_accessor.Compile()(person);

                property_name.ShouldEqual("name");
                property_value.ShouldEqual("jp");
            };

            It should_be_able_to_build_an_expression_tree_in_code = () =>
            {
                var number3 = Expression.Constant(3);
                var number2 = Expression.Constant(2);
                var add_2_numbers = Expression.Add(number3, number2);
                var expression = Expression.Lambda<Func<int>>(add_2_numbers);

                expression.Compile()().ShouldEqual(5);
            };
        }
    }

    class Person
    {
        public string name { get; set; }
        public string address { get; set; }
        public int age { get; set; }
    }
}