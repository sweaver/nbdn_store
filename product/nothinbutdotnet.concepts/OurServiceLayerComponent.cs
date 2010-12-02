using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace nothinbutdotnet.concepts
{
    public interface Service
    {
        string display_contents_of(string file_name);
    }

    public interface SomeSpecialFeature
    {
    }

    public class SecuredComponent : Service, SomeSpecialFeature
    {
        Service service;

        public SecuredComponent(Service service)
        {
            this.service = service;
        }

        public string display_contents_of(string file_name)
        {
            return Thread.CurrentPrincipal.IsInRole("Special")
                ? service.display_contents_of(file_name)
                : "Not authorized";
        }
    }

    public interface DataAccess
    {
        IEnumerable<string> names();
    }

    class BasicDataAccess : DataAccess
    {
        public IEnumerable<string> names()
        {
            return Enumerable.Range(1, 1000000).Select(x => x.ToString("This is a really long name 0"));
        }
    }

    class CachingDataAccess : DataAccess
    {
        DataAccess data_access;
        IList<string> cached;

        public CachingDataAccess(DataAccess data_access)
        {
            this.data_access = data_access;
        }

        public IEnumerable<string> names()
        {
            return cached ?? (cached = data_access.names().ToList());
        }
    }

    public class OurServiceLayerComponent : Service
    {
        DataAccess data_access;

        public OurServiceLayerComponent(DataAccess data_access)
        {
            this.data_access = data_access;
        }

        public string display_contents_of(string file_name)
        {
            return File.ReadAllText(file_name) + data_access.names();
        }
    }
}