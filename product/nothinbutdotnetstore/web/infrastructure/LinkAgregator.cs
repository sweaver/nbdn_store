namespace nothinbutdotnetstore.web.infrastructure
{
    public class LinkAgregator<ViewToRun> 
    {
        public string include(string departmentName,string key)
        {
            return string.Format("{0}/storecontroller.store?{1}={2}",
                                 typeof(ViewToRun).Name, key, departmentName);
        }
    }
}