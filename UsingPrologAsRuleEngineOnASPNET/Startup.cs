using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.StaticFiles.ContentTypes;
using Owin;

[assembly: OwinStartup(typeof(UsingPrologAsRuleEngineOnASPNET.Startup))]

namespace UsingPrologAsRuleEngineOnASPNET
{
    public class CustomContentTypeProvider : FileExtensionContentTypeProvider
    {
        public CustomContentTypeProvider()
        {
            Mappings.Add(".pl", "text/plain");
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.UseDefaultFiles();

            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            app.UseStaticFiles(new StaticFileOptions
            {
                FileSystem = new PhysicalFileSystem(root: baseDir),
                ServeUnknownFileTypes = false,
                ContentTypeProvider = new CustomContentTypeProvider()
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}
