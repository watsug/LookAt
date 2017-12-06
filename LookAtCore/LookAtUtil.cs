using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Composition.Hosting;
using LookAtApi.Interfaces;

namespace LookAtCore
{
    public class LookAtUtil
    {
        public const string PluginsFolder = "Plugins";

        public static IEnumerable<IPlugin> LoadPlugins()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(location), PluginsFolder);
            IEnumerable<IPlugin> plugins =
                LookAtUtil.LoadPlugins(path, "*.dll");
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

        public static IEnumerable<IVisibleObject> DoSearch(IEnumerable<IPlugin> plugins, IVisibleObject obj, int generations = 1)
        {
            List<IVisibleObject> results = new List<IVisibleObject>();
            foreach (var plugin in plugins)
            {
                foreach (var t in plugin.Transformations)
                {
                    try
                    {
                        if (obj.Transformation != null && t.GetType() == obj.Transformation.GetType())
                        {
                            // skip cycles
                            continue;
                        }

                        IVisibleObject tmp = t.DoTransformation(obj);
                        if (tmp != null)
                        {
                            results.Add(tmp);
                        }
                    }
                    catch (Exception)
                    {
                        // TODO: add warning here
                    }
                }
            }
            if (generations - 1 > 0)
            {
                List<IVisibleObject> gen1 = new List<IVisibleObject>();
                foreach (var res in results)
                {
                    if (res.Final) continue;
                    IEnumerable<IVisibleObject> tmp = DoSearch(plugins, res, generations - 1);
                    gen1.AddRange(tmp);
                }
                results.AddRange(gen1);
            }
            return results;
        }
    }
}
