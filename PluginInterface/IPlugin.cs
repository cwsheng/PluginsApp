using System;

namespace PluginInterface
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        string Execute(object inPars);
    }
}
