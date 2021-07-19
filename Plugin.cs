using Synapse.Api;
using Synapse.Api.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChat
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "Chat with other players!",
        LoadPriority = 0,
        Name = "TextChat",
        SynapseMajor = 2,
        SynapseMinor = 6,
        SynapsePatch = 0,
        Version = "1.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "TextChat")]
        public static Config Config;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("TextChat loaded!");


        }

        public override void ReloadConfigs()
        {

        }
    }
}
