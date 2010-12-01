using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubRequestCommands : IEnumerable<RequestCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<RequestCommand> GetEnumerator()
        {
            yield return new DefaultRequestCommand(x => true,
                                                   new ViewMainDepartmentsInTheStore());
        }
    }
}