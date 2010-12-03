using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.repositories.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDetails<Detail> : ApplicationCommand
    {
        Repository repository;
        ResponseEngine response_engine;
        GetTheDetails<Detail> query;

        public ViewDetails(GetTheDetails<Detail> query):this(new StubRepository(),
            new WebFormResponseEngine(),query)
        {
        }

        public ViewDetails(Repository repository, ResponseEngine response_engine, GetTheDetails<Detail> query)
        {
            this.repository = repository;
            this.query = query;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(query(repository,request));
        }
    }
}