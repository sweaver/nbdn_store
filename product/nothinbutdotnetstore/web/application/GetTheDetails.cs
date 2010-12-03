using System.Collections.Generic;
using nothinbutdotnetstore.repositories;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public delegate IEnumerable<Detail> GetTheDetails<Detail>(Repository repository,Request request);
}