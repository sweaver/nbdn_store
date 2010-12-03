using System;
using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.repositories.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public abstract class View : ApplicationCommand
    {
        public Repository repository;
        public ResponseEngine response_engine;

        protected View() : this(new StubRepository(), new WebFormResponseEngine())
        {
        }

        protected View(Repository repository, ResponseEngine responseEngine)
        {
            this.repository = repository;
            this.response_engine = responseEngine;
        }

        public void process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}