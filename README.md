# TextChat
Chat with other players!

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

## Features
* Teamchat: Chat with other players in your same team (MTF, CI etc.)
* Globalchat: Chat with all players on the server (I recommend to turn it off because players can ghost with it)
* Privatechat: Chat with a certain user (I recommend to turn it off because players can ghost with it)
* Adminchat: Chat with staff.

## Installation
1. [Install Synapse](https://github.com/SynapseSL/Synapse/wiki#hosting-guides)
2. Place the TextChat.dll file that you can download [here](https://github.com/TheVoidNebula/TextChat/releases) in your plugin directory
3. Restart/Start your server.

## Commands
Command  | Usage | Aliases | Permission | Description 
------------ |  ------------ | ------------ |------------ | ------------ 
`SpyMode` | `spymode` | sm | tc.spymode | See private messages and team messages from other teams.
`AdminChat` | `.adminchat <Message>` | ac | tc.adminchat | Chat with staff on the server.
`TeamChat` | `.teamchat <Message>` | tc | / | Chat with other players in your same team (MTF, CI etc.)
`GlobalChat` | `.globalchat <Message>` | gc | / | Chat with all players on the server (I recommend to turn it off because players can ghost with it)
`PrivateChat` | `.privatechat <Player> <Message>` | pc | / | Chat with a certain user (I recommend to turn it off because players can ghost with it)

## Config
Name  | Type | Default | Description
------------ | ------------ | ------------- | ------------ 
`IsEnabled` | Boolean | true | Is this plugin enabled?
`EnableGlobalChat` | Boolean | true | Should players be allowed to use the global chat?
`EnableTeamChat` | Boolean | true | Should players be allowed to use the team chat?
`EnablePrivateChat` | Boolean | true | Should players be allowed to use the private chat?
`EnableAdminChat` | Boolean | true | Should players be allowed to use the admin chat?
`MessageType` | MessageType | Hint | Where should the messages be posted?
`GlobalChatColor` | String | #F6F20C | Which color should the globalchat use?
`TeamChatColor` | String | #01FF1C | Which color should the teamchat use?
`AdminChatColor` | String | #FF0000 | Which color should the adminchat use?
`PrivatChatColor` | String | #05FFD7 | Which color should the privatechat use?

## Config.yml
```yml
[TextChat]
{
# Should the Plugin be enabled?
isEnabled: true
# Should players be allowed to use the global chat?
enableGlobalChat: true
# Should players be allowed to use the team chat?
enableTeamChat: true
# Should players be allowed to use the private chat?
enablePrivateChat: true
# Should players be allowed to use the admin chat?
enableAdminChat: true
# Should the sender of the message see the message like everyone else?
showMessageToSelf: true
# Where should the messages be posted?
messageType: Hint
# Which color should the globalchat use?
globalChatColor: '#F6F20C'
# Which color should the teamchat use?
teamChatColor: '#01FF1C'
# Which color should the adminchat use?
adminChatColor: '#FF0000'
# Which color should the privatechat use?
privatChatColor: '#05FFD7'
}
```
