namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicDependencyContainer : DependencyContainer
    {
        DependencyBuilders builder_registry;

        public BasicDependencyContainer(DependencyBuilders builder_registry)
        {
            this.builder_registry = builder_registry;
        }

        public Dependency an<Dependency>()
        {
            return (Dependency) builder_registry.get_the_builder_to_build<Dependency>().build();
        }
    }
}