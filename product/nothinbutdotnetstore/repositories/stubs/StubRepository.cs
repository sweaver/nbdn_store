using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.repositories.stubs
{
    public class StubRepository : Repository
    {
        public IEnumerable<Department> get_all_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_all_departments_in(Department department)
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("SubDepartment 0")});
        }
    }
}