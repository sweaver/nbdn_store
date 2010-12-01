using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubResponseEngine : ResponseEngine
    {
        public void display(object item_to_display)
        {
            HttpContext.Current.Items.Add("blah", item_to_display);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx", true);
        }
    }
}