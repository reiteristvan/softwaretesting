using BlogIn.DataAccess;
using BlogIn.Services;
using Microsoft.Practices.Unity;

namespace BlogIn.Infrastructure
{
    public static class UnityConfiguration
    {
        public static void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IPostRepository, PostRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBlogService, BlogService>(new ContainerControlledLifetimeManager());
        }
    }
}