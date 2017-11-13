using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Composition.Hosting;
using LookAtApi.Interfaces;

namespace LookAtCore
{
    public class PluginLoader
    {
        public const string PluginsFolder = "Plugins";

        public static IEnumerable<IPlugin> LoadPlugins()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(location), PluginsFolder);
            IEnumerable<IPlugin> plugins =
                PluginLoader.LoadPlugins(path, "*.dll");
            return plugins;
        }

        public static IEnumerable<IPlugin> LoadPlugins(string path, string fileMask)
        {
            List<IPlugin> ret = new List<IPlugin>();
            var files = Directory.EnumerateFiles(path, fileMask);
            foreach (var file in files)
            {
                try
                {
                    Assembly a = Assembly.LoadFile(file);
                    var configuration = new ContainerConfiguration()
                        .WithAssembly(a);
                    using (var container = configuration.CreateContainer())
                    {
                        ret.AddRange(container.GetExports<IPlugin>());
                    }
                }
                catch (Exception)
                {
                    // TODO: add warning here
                }
            }
            return ret;
        }
    }
}
