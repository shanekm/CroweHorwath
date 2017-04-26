using System.Web.Http;
using Contracts;
using Contracts.Abstract;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace RestfulService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IApplicationSettings, ConfigAppSettings>();
            container.RegisterType<IStoreReader, FileStore>();
            container.RegisterType<IStoreWriter, FileStore>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}