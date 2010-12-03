using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : View
    {


        public new void process(Request request)
        {
            response_engine.display(repository.get_all_main_departments());
        }
    }
}