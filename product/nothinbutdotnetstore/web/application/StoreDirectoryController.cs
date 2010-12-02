using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.repositories;

namespace nothinbutdotnetstore.web.application
{
    public class StoreDirectoryController
    {
        Repository repository;

        public StoreDirectoryController(Repository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Department> get_all_main_departments()
        {
            return repository.get_all_main_departments();
        }

        public IEnumerable<Department> get_the_departments_in_a(Department department)
        {
            return repository.get_all_departments_in(department);
        }
    }
}