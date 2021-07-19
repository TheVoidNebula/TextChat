using Synapse.Api;
using Synapse.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChat.Commands
{
    [CommandInformation(
        Name = "spymode",
        Aliases = new[] { "sm" },
        Description = "Be able to see every message written in any text chats.",
        Permission = "tc.spy",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "spymode"
        )]
    public class SpyMode : ISynapseCommand
    {
        public static HashSet<Player> inSpyMode = new HashSet<Player>();

        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Player player = context.Player;

            if (!player.HasPermission("tc.spy"))
            {
                result.Message = "You do not have the permission tc.spy!";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if (inSpyMode.Contains(player))
            {
                inSpyMode.Remove(player);
                result.Message = "You have disabled spymode!";
                result.State = CommandResultState.Ok;
                return result;
            }
            else
            {
                inSpyMode.Add(player);
                result.Message = "You have enabled spymode!";
                result.State = CommandResultState.Ok;
                return result;
            }
        }
    }
}
