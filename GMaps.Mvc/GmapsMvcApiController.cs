﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.IO;
using GMaps.Mvc.Extensions;

namespace GMaps.Mvc
{
    public class GMapsMvcApiController : Controller
    {
        public ActionResult EmbeddedScripts()
        {
            var type = this.GetType();
            var assembly = System.Reflection.Assembly.GetAssembly(type);
            var scriptNamespace = $"{type.Namespace}.Scripts";
            var scripts = assembly.GetManifestResourceNames()
                .Where(x => x.StartsWith(scriptNamespace))
                .ToList()
            ;
            scripts.Prioritize(x => x.EndsWith("gmaps.mvc.js"));
            using (var writer = new StringWriter())
            {
                foreach (var script in scripts)
                {
                    using (Stream stream = assembly.GetManifestResourceStream(script))
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