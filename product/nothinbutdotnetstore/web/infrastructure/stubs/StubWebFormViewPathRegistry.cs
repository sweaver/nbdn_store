namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubWebFormViewPathRegistry : WebFormViewPathRegistry
    {
        public string get_path_to_view_that_can_display<ViewModel>()
        {
            return "~/views/DepartmentBrowser.aspx";
        }
    }
}