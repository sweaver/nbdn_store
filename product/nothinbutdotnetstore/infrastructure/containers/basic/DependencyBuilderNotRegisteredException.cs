using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyBuilderNotRegisteredException :Exception
    {
        public Type type_that_has_no_builder { get; private set; }
    }
}