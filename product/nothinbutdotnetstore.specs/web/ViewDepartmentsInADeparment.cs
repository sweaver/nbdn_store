using System;
using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentsInADeparment : ApplicationCommand
    {
        Repository department_repository;
        ResponseEngine response_engine;

        

        public void process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}