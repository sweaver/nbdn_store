 
using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.specs.web
{
    public class LinkBuilderSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof (LinkBuilder))]
        public class when_link_build_requested : concern
        {
            private Establish e = () =>
                                  department = new Department() { name = "grocery"};

            
            private Because b = () =>
                                result = LinkBuilder.to_run<ViewDepartmentsInDepartment>()
                                             .include(department.name, InputKeys.department_name);


            private It should_return_link_with_department = () =>
                                                            result.ShouldEqual(
                                                                string.Format(
                                                                "ViewDepartmentsInDepartment/storecontroller.store?{0}={1}",
                                                                InputKeys.department_name,department.name
                                                                ));
                
            private static string result;
            private static Department department;

        }
    }
}
