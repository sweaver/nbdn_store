using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.repositories.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        Repository department_repository;
        ResponseEngine response_engine;

        public ViewMainDepartmentsInTheStore() : this(new StubRepository(),
                                                      new WebFormResponseEngine())
        {
        }

        public ViewMainDepartmentsInTheStore(Repository department_repository, ResponseEngine response_engine)
        {
            this.department_repository = department_repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(department_repository.get_all_main_departments());
        }
    }
}