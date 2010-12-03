using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubWebFormViewPathRegistry : WebFormViewPathRegistry
    {
        public string get_path_to_view_that_can_display<ViewModel>()
        {
            if (typeof(ViewModel) == typeof(IEnumerable<Department>)) return "~/views/DepartmentBrowser.aspx";

            return "~/views/ProductBrowser.aspx";
        }
    }
}