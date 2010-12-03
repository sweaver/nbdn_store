using System;

namespace nothinbutdotnetstore.infrastructure
{
    public class Container
    {
        private static DependencyContainer container;

        public static ContainerResolver resolver = () =>
                                                       {
                                                           container = new DefaultContainer();
                                                           return container;
                                                       };

        public static DependencyContainer resolve
        {
            get { return container; }
        }
    }
}