using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.IO;
using GMaps.Mvc.Extensions;
using System.Reflection;

namespace GMaps.Mvc
{
    public class GMapsMvcApiController : Controller
    {
        protected Type EmbeddingAccessType => this.GetType();
        protected Assembly EmbeddingAssembly => System.Reflection.Assembly.GetAssembly(typeof(GMapsMvcApiController));
        protected string RootEmbeddingNamespace => this.EmbeddingAccessType.Namespace;
        public ActionResult MarkerClusterIcon(int size)
        {
            var resourceName = $"{RootEmbeddingNamespace}.Content.markerclusterer.m{size}.png";
            var icons = this.EmbeddingAssembly.GetManifestResourceNames()
                .Where(x => x.StartsWith($"{RootEmbeddingNamespace}.Content"))
                .ToList()
            ;
            var stream = this.EmbeddingAssembly.GetManifestResourceStream(resourceName);
            return this.File(stream, "image/png");
        }
        public ActionResult Scripts()
        {
            var scriptNamespace = $"{RootEmbeddingNamespace}.Scripts";
            var scripts = this.EmbeddingAssembly.GetManifestResourceNames()
                .Where(x => x.StartsWith(scriptNamespace))
                .ToList()
            ;
            scripts.Prioritize(x => x.EndsWith("gmaps.mvc.js"));
            using (var writer = new StringWriter())
            {
                foreach (var script in scripts)
                {
                    using (Stream stream = this.EmbeddingAssembly.GetManifestResourceStream(script))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            writer.WriteLine(reader.ReadToEnd());
                        }
                    }
                }
                var content = writer.ToString();
                return this.JavaScript(content);
            }
        }
    }
}
