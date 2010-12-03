using System;

namespace nothinbutdotnetstore.infrastructure
{
    public class Container
    {
        public static ContainerResolver resolver = () =>
        {
            throw new NotImplementedException("This needs to be configured by a startup process");
        };

        public static DependencyContainer resolve
        {
            get { throw new NotImplementedException(); }
        }
    }
}