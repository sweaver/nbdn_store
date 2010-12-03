using nothinbutdotnetstore.model;
using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.repositories.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentsInADeparment : ApplicationCommand
    {
        Repository department_repository;
        ResponseEngine response_engine;

        public ViewDepartmentsInADeparment():this(new StubRepository(),
                                                  new WebFormResponseEngine())
        {
        }

        public ViewDepartmentsInADeparment(Repository department_repository, ResponseEngine response_engine)
        {
            this.department_repository = department_repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(department_repository.get_all_departments_in(request.map<Department>()));
        }
    }
}