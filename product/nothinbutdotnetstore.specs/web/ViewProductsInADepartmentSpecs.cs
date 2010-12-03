using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web {
    public class ViewProductsInADepartmentSpecs {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewProductsInADepartment> {

        }

        [Subject(typeof(ViewProductsInADepartment))]
        public class when_viewing_products_in_a_department : concern {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                department_repository = the_dependency<Repository>();
                department = new Department();
                provide_a_basic_sut_constructor_argument(department);
                products_in_a_department = new List<Product> {new Product()};
                request = an<Request>();

                request.Stub(x => x.map<Department>()).Return(department);
                department_repository.Stub(x => x.get_products_in(department)).Return(products_in_a_department);
            };

            Because b = () =>
                sut.process(request);


            It should_display_the_list_of_products_within_a_department = () =>
                response_engine.received(x => x.display(products_in_a_department));

            private static Department department;
            static Repository department_repository;
            static Request request;
            static ResponseEngine response_engine;
            static IEnumerable<Product> products_in_a_department;
        }
    }
}
