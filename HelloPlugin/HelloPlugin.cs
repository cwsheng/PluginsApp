using System;

namespace HelloPlugin
{
    public class HelloPlugin : PluginInterface.IPlugin
    {
        public string Name => "HelloPlugin";
        public string Description { get => "Displays hello message."; }
        public string Execute(object inPars)
        {
            return ("Hello !!!" + inPars?.ToString());
        }
    }
}
