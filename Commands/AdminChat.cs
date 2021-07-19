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
        Name = "adminchat",
        Aliases = new[] { "ac" },
        Description = "Type in the admin chat. People who have the permission tc.adminchat can read this.",
        Permission = "",
        Platforms = new[] { Platform.ClientConsole, Platform.RemoteAdmin },
        Usage = ".adminchat <Message>"
        )]
    public class AdminChat : ISynapseCommand
    {

        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Player player = context.Player;
            string message = "";

            if(Plugin.Config.IsEnabled && Plugin.Config.EnableAdminChat && player.HasPermission("tc.adminchat"))
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
                                    if (players.HasPermission("tc.adminchat"))
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.AdminChatColor}>Admin</color>] {player.DisplayName} <color={Plugin.Config.AdminChatColor}>" + message + "</color>");
                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.AdminChatColor}>Admin</color>] {player.DisplayName} <color={Plugin.Config.AdminChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                            else
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (players != player && players.HasPermission("tc.adminchat"))
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.AdminChatColor}>Admin</color>] {player.DisplayName} <color={Plugin.Config.TeamChatColor}>" + message + "</color>");
                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.AdminChatColor}>Admin</color>] {player.DisplayName} <color={Plugin.Config.AdminChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                        case MessageType.Hint:
                            if (Plugin.Config.ShowMessageToSelf)
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (players.HasPermission("tc.adminchat"))
                                        players.GiveTextHint($"[<color={Plugin.Config.AdminChatColor}>Admin</color>] {player.DisplayName} <color={Plugin.Config.AdminChatColor}>" + message + "</color>");
                                }
                                result.Message = $"[<color={Plugin.Config.AdminChatColor}>Admin</color>] {player.DisplayName} <color={Plugin.Config.AdminChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                            else
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (players != player && players.HasPermission("tc.adminchat"))
                                        players.GiveTextHint($"[<color={Plugin.Config.AdminChatColor}>Admin</color>] {player.DisplayName} <color={Plugin.Config.AdminChatColor}>" + message + "</color>");
                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.AdminChatColor}>Admin</color>] {player.DisplayName} <color={Plugin.Config.AdminChatColor}>" + message + "</color>";
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
                    result.Message = "Usage: .adminchat <Message>";
                    result.State = CommandResultState.Error;
                    return result;
                }
            }
            else
            {
                result.Message = "Admin Chat is currently disabled.";
                result.State = CommandResultState.Error;
                return result;
            }
        }
    }
}
