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
        Name = "privatechat",
        Aliases = new[] { "pc" },
        Description = "Type in the private chat. You can chat with one person privatly.",
        Permission = "",
        Platforms = new[] { Platform.ClientConsole },
        Usage = ".privatechat <Player> <Message>"
        )]
    public class PrivateChat : ISynapseCommand
    {

        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Player player = context.Player;
            string message = "";

            if(Plugin.Config.IsEnabled && Plugin.Config.EnablePrivateChat)
            {
                if(context.Arguments.Count >= 2)
                {
                    for (int i = 1; i < context.Arguments.Count; i++)
                        message = message + context.Arguments.Array[i+1] + " ";
                    Player player2 = Server.Get.GetPlayer(context.Arguments.Array[1]);
                    switch (Plugin.Config.MessageType)
                    {
                        case MessageType.Broadcast:
                            if (Plugin.Config.ShowMessageToSelf)
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (player2 != null)
                                    {
                                        player.SendBroadcast(5, $"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                        player2.SendBroadcast(5, $"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                    }
                                       
                                    if (player2 != null && player != players && player2 != players && SpyMode.inSpyMode.Contains(players))
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.PrivatChatColor}>Privat-Spy</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                            else
                            {
                                foreach (Player players in Server.Get.Players)
                                {

                                    if (player2 != null && player2 != player)
                                        player2.SendBroadcast(5, $"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                    if (player2 != null && player != players && player2 != players && SpyMode.inSpyMode.Contains(players) && player2 != player)
                                        players.SendBroadcast(5, $"[<color={Plugin.Config.PrivatChatColor}>Privat-Spy</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");

                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                        case MessageType.Hint:
                            if (Plugin.Config.ShowMessageToSelf)
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (player2 != null && player2 != player)
                                    {
                                        player.GiveTextHint($"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                        player2.GiveTextHint($"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                    }
                                    if (player2 != null && player != players && player2 != players && SpyMode.inSpyMode.Contains(players) && player2 != player)
                                        players.GiveTextHint($"[<color={Plugin.Config.PrivatChatColor}>Privat-Spy</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                }
                                result.Message = $"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>";
                                result.State = CommandResultState.Ok;
                                return result;
                            }
                            else
                            {
                                foreach (Player players in Server.Get.Players)
                                {
                                    if (player2 != null && player2 != player)
                                        player2.GiveTextHint($"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                    if (player2 != null && player != players && player2 != players && SpyMode.inSpyMode.Contains(players) && player2 != player)
                                        players.GiveTextHint($"[<color={Plugin.Config.PrivatChatColor}>Privat-Spy</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>");
                                }
                                result.Message = $"Message send!\n" + $"[<color={Plugin.Config.PrivatChatColor}>Privat</color>] [{player.DisplayName} -> {player2.DisplayName}]: <color={Plugin.Config.PrivatChatColor}>" + message + "</color>";
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
                    result.Message = "Usage: .privatchat <Player> <Message>";
                    result.State = CommandResultState.Error;
                    return result;
                }
            }
            else
            {
                result.Message = "Privat Chat is currently disabled.";
                result.State = CommandResultState.Error;
                return result;
            }
        }
    }
}
