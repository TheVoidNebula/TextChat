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
        Name = "teamchat",
        Aliases = new[] { "tc" },
        Description = "Type in the team chat. People in the same team can read this.",
        Permission = "",
        Platforms = new[] { Platform.ClientConsole },
        Usage = ".teamchat <Message>"
        )]
    public class TeamChat : ISynapseCommand
    {

        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Player player = context.Player;
            string message = "";

            if(Plugin.Config.IsEnabled && Plugin.Config.EnableTeamChat)
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
                                {
                                    if (player.TeamID == players.TeamID)
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.TeamChatColor}>Team</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                    if (player.TeamID != players.TeamID && SpyMode.inSpyMode.Contains(players))
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.TeamChatColor}>Team-Spy</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.TeamChatColor}>Team</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                            else
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (players != player && player.TeamID == players.TeamID)
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.TeamChatColor}>Team</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                    if (players != player && player.TeamID != players.TeamID && SpyMode.inSpyMode.Contains(players))
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.TeamChatColor}>Team-Spy</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.TeamChatColor}>Team</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                        case MessageType.Hint:
                            if (Plugin.Config.ShowMessageToSelf)
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (player.TeamID == players.TeamID)
                                        players.GiveTextHint($"[<color={Plugin.Config.TeamChatColor}>Team</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                    if (player.TeamID != players.TeamID && SpyMode.inSpyMode.Contains(players))
                                        players.GiveTextHint($"[<color={Plugin.Config.TeamChatColor}>Team-Spy</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                }
                                result.Message = $"[<color={Plugin.Config.TeamChatColor}>Team</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                            else
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (players != player && player.TeamID == players.TeamID)
                                        players.GiveTextHint($"[<color={Plugin.Config.TeamChatColor}>Team</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                    if (players != player && player.TeamID != players.TeamID && SpyMode.inSpyMode.Contains(players))
                                        players.GiveTextHint($"[<color={Plugin.Config.TeamChatColor}>Team-Spy</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.TeamChatColor}>Team</color>] {player.DisplayName}: <color={Plugin.Config.TeamChatColor}>" + message + "</color>";
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
                    result.Message = "Usage: .teamchat <Message>";
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
