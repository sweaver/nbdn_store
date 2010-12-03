using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStoreBase : ApplicationCommand
    {
        protected Repository department_repository;
        protected ResponseEngine response_engine;

        public void process(Request request)
        {
            response_engine.display(department_repository.get_all_main_departments());
        }
    }
}