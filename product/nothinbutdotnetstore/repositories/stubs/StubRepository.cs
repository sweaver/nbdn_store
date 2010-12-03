using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.repositories.stubs
{
    public class Factories
    {
        public static Func<int, Department> basic_department =
            number => create_department(number.ToString("Department 0"), false);



        public static Func<int, Department> create_sub_department =
            number => create_department(number.ToString("Sub Department 0"), number%2 == 0);


        public static Department create_department(string name,bool has_products)
        {
            return new Department {name = name, has_products = has_products};
        }

    }
    public class StubRepository : Repository
    {
        public IEnumerable<Department> get_all_main_departments()
        {
            return create_a_set_of(100,Factories.basic_department);
        }

        public IEnumerable<Department> get_all_departments_in(Department department)
        {
            return create_a_set_of(100,Factories.create_sub_department);
        }

        public IEnumerable<Product> get_products_in(Department department)
        {
            return create_a_set_of(10, x => new Product {name = x.ToString("Product 0")});
        }

        public IEnumerable<ElementToCreate> create_a_set_of<ElementToCreate>(int quantity,
                                                                             Func<int, ElementToCreate> factory)
        {
            return Enumerable.Range(1, quantity).Select(factory);
        }
    }
}