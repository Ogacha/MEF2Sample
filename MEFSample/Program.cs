using AddinContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MEFSample
{
    public class PluginHost
    {
        //[System.Composition.ImportMany]
        [System.ComponentModel.Composition.ImportMany]
        public List<IAddinContract> Addins
        {
            get;
            set;
        }

        static public PluginHost Create()
        {
            var builder = new System.ComponentModel.Composition.Registration.RegistrationBuilder();

            // addins
            builder
                .ForTypesDerivedFrom<IAddinContract>()
                //.Export<IAddinContract>()
                .ExportInterfaces()
                ;

            // host
            builder
                    .ForType<PluginHost>()
                    //.ImportProperty(x => x.Addins, b => b.AsMany())
                    .Export<PluginHost>()
                    ;

            var hostCatalog = new System.ComponentModel.Composition.Hosting.AssemblyCatalog(typeof(PluginHost).Assembly, builder);
            var aCataog = new System.ComponentModel.Composition.Hosting.AggregateCatalog(hostCatalog);

#if false
            var catalog = new System.ComponentModel.Composition.Hosting.DirectoryCatalog("addins");
            aCataog.Catalogs.Add(catalog);
#else
            foreach (var f in new DirectoryInfo("addins").GetFiles().Where(x => x.Name.ToLower().EndsWith(".dll")))
            {
                var catalog = new System.ComponentModel.Composition.Hosting.AssemblyCatalog(Assembly.LoadFile(f.FullName), builder);
                aCataog.Catalogs.Add(catalog);
            }
#endif

            var container = new System.ComponentModel.Composition.Hosting.CompositionContainer(aCataog);
#if false
            var host = new PluginHost();
            container.ComposeParts(host);
            return host;
#else
            return container.GetExportedValue<PluginHost>();
#endif
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var host = PluginHost.Create();

            foreach (var addin in host.Addins)
            {
                addin.DoWork();
                Console.WriteLine(addin.AddinTitle);
            }    
        }
    }
}
