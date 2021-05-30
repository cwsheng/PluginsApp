using Newtonsoft.Json;
using System;
using System.Reflection;

namespace JsonPlugin
{
    public class JsonPlugin : PluginInterface.IPlugin
    {
        public string Name => "JsonPlugin";

        public string Description => "Outputs JSON value.";

        private struct Info
        {
            public string JsonVersion;
            public string JsonLocation;
            public string Machine;
            public DateTime Date;
        }
        public string Execute(object inPars)
        {
            Assembly jsonAssembly = typeof(JsonConvert).Assembly;
            Info info = new Info()
            {
                JsonVersion = jsonAssembly.FullName,
                JsonLocation = jsonAssembly.Location,
                Machine = Environment.MachineName,
                Date = DateTime.Now
            };

            return JsonConvert.SerializeObject(info, Formatting.Indented);
        }
    }
}
