using System.Reflection;
using System.Collections.Generic;
using System.Composition.Hosting;
using LookAtApi.Interfaces;

namespace LookAtCore
{
    public class PluginLoader
    {
        public static IEnumerable<IPlugin> LoadPlugins()
        {
            List<Assembly> assemblies = new List<Assembly>();
            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies);
            using (var container = configuration.CreateContainer())
            {
                return container.GetExports<IPlugin>();
            }
        }
    }
}
