using Synapse.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChat
{
    public class Config : AbstractConfigSection
    {
        [Description("Should the Plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should players be allowed to use the global chat?")]
        public bool EnableGlobalChat { get; set; } = true;

        [Description("Should players be allowed to use the team chat?")]
        public bool EnableTeamChat { get; set; } = true;

        [Description("Should players be allowed to use the private chat?")]
        public bool EnablePrivateChat { get; set; } = true;

        [Description("Should players be allowed to use the admin chat?")]
        public bool EnableAdminChat { get; set; } = true;

        [Description("Should the sender of the message see the message like everyone else?")]
        public bool ShowMessageToSelf { get; set; } = true;

        [Description("Where should the messages be posted?")]
        public MessageType MessageType { get; set; } = MessageType.Hint;

        [Description("Which color should the globalchat use?")]
        public string GlobalChatColor { get; set; } = "#F6F20C";

        [Description("Which color should the teamchat use?")]
        public string TeamChatColor { get; set; } = "#01FF1C";

        [Description("Which color should the adminchat use?")]
        public string AdminChatColor { get; set; } = "#FF0000";

        [Description("Which color should the privatechat use?")]
        public string PrivatChatColor { get; set; } = "#05FFD7";
    }
}
