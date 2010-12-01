 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.repositories;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{   
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewMainDepartmentsInTheStore>
        {
        
        }

        [Subject(typeof(ViewMainDepartmentsInTheStore))]
        public class when_viewing_the_main_departments_in_the_store : concern
        {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                department_repository = the_dependency<Repository>();
                the_main_departments = new List<Department> {new Department()};
                request = an<Request>();


                department_repository.Stub(x => x.get_all_main_departments()).Return(the_main_departments);
            };

            Because b = () =>
                sut.process(request);


            It should_display_the_list_of_departments = () =>
                response_engine.received(x => x.display(the_main_departments));


            static Repository department_repository;
            static Request request;
            static ResponseEngine response_engine;
            static IEnumerable<Department> the_main_departments;
        }
    }
}
