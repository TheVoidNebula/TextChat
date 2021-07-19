using Synapse;
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
        Name = "globalchat",
        Aliases = new[] { "gc" },
        Description = "Type in the global chat. Everyone on the server can read this.",
        Permission = "",
        Platforms = new[] { Platform.ClientConsole },
        Usage = ".globalchat <Message>"
        )]
    public class GlobalChat : ISynapseCommand
    {

        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Player player = context.Player;
            string message = "";

            if(Plugin.Config.IsEnabled && Plugin.Config.EnableGlobalChat)
            {
                if(context.Arguments.Count >= 1)
                {
                    for (int i = 0; i < context.Arguments.Count; i++)
                        message = message + context.Arguments.Array[i+1] + " ";
                    switch (Plugin.Config.MessageType)
                    {
                        case MessageType.Broadcast:
                            if (Plugin.Config.ShowMessageToSelf)
                            {
                                foreach (Player players in Server.Get.Players)
                                    players.SendBroadcast(5, $"[<color={Plugin.Config.GlobalChatColor}>Global</color>] {player.DisplayName}: <color={Plugin.Config.GlobalChatColor}>" + message + "</color>");
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.GlobalChatColor}>Global</color>] {player.DisplayName}: <color={Plugin.Config.GlobalChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                            else
                            {
                                foreach (Player players in Server.Get.Players)
                                    if (players != player)
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.GlobalChatColor}>Global</color>] {player.DisplayName}: <color={Plugin.Config.GlobalChatColor}>" + message + "</color>");
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.GlobalChatColor}>Global</color>] {player.DisplayName}: <color={Plugin.Config.GlobalChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                        case MessageType.Hint:
                            if (Plugin.Config.ShowMessageToSelf)
                            {
                                foreach (Player players in Server.Get.Players)
                                    players.GiveTextHint($"[<color={Plugin.Config.GlobalChatColor}>Global</color>] {player.DisplayName}: <color={Plugin.Config.GlobalChatColor}>" + message + "</color>");
                                result.Message = $"[<color={Plugin.Config.GlobalChatColor}>Global</color>] {player.DisplayName}: <color={Plugin.Config.GlobalChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                            else
                            {
                                foreach (Player players in Server.Get.Players)
                                    if (players != player)
                                        players.GiveTextHint($"[<color={Plugin.Config.GlobalChatColor}>Global</color>] {player.DisplayName}: <color={Plugin.Config.GlobalChatColor}>" + message + "</color>");
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.GlobalChatColor}>Global</color>] {player.DisplayName}: <color={Plugin.Config.GlobalChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                        default:
                            result.Message = "You need to determine Hint or Broadcast.";
                            result.State = CommandResultState.Error;
                            return result;
                    }
                } 
                else
                {
                    result.Message = "Usage: .globalchat <Message>";
                    result.State = CommandResultState.Error;
                    return result;
                }
            }
            else
            {
                result.Message = "Global Chat is currently disabled.";
                result.State = CommandResultState.Error;
                return result;
            }
        }
    }
}
