using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web {
    public class ViewDepartmensInADepartmentSpecs {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewDepartmentsInADeparment> {

        }

        [Subject(typeof(ViewDepartmentsInADeparment))]
        public class when_viewing_the_departments_in_a_department : concern {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                department = new Department();
                provide_a_basic_sut_constructor_argument(department);
                departments_in_a_department = new List<Department> {new Department()};
                request = an<Request>();

                request.Stub(x => x.map<Department>()).Return(department);
                department_repository.Stub(x => x.get_all_departments_in(department)).Return(departments_in_a_department);
            };

            Because b = () =>
                sut.process(request);


            It should_display_the_list_of_departments_within_a_department = () =>
                response_engine.received(x => x.display(departments_in_a_department));

            private static Department department;
            static Repository department_repository;
            static Request request;
            static ResponseEngine response_engine;
            static IEnumerable<Department> departments_in_a_department;
        }
    }
}
