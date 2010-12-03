using nothinbutdotnetstore.model;
using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.repositories.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentsInADeparment : View
    {
        
        public void process(Request request)
        {
            response_engine.display(repository.get_all_departments_in(request.map<Department>()));
        }
    }
}