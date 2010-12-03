using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInADepartment : View
    {
        public void process(Request request)
        {
            response_engine.display(repository.get_products_in(request.map<Department>()));
        }
    }
}