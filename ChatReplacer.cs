using Terraria;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Chat.Commands;
using Terraria.UI.Chat;
using Terraria.Localization;
using System;

namespace ChatReplacer {
public class ChatReplacer : Mod
{

    public override void Load()
    {
	On_ChatCommandProcessor.CreateOutgoingMessage += CreateOutgoingMessage;
    }

    private static ChatMessage CreateOutgoingMessage(On_ChatCommandProcessor.orig_CreateOutgoingMessage orig, ChatCommandProcessor self, string text)
    {
	ChatMessage chatMessage = orig(self, text);
	string newText = "";
	Random random = new Random();
	foreach (String t in chatMessage.Text.Split(' ')) {
	    if (random.NextDouble() < 0.5) {
		if (random.NextDouble() < 0.5) {
		    newText += "Word ";
	    	}
		else {
		    newText += "word ";
		}
	    }
	    newText += t + " ";
	}
	chatMessage.Text = newText.Trim();
	return chatMessage;
    }

/*
    public override void Load()
    {
	On_ChatHelper.SendChatMessageFromClient += SendChatMessageFromClient;
    }

    private static void SendChatMessageFromClient(On_ChatHelper.orig_SendChatMessageFromClient orig, ChatMessage message)
    {
	ChatMessage chatMessage = orig(message);
        // Check if the message is "hello there"
        if (message.Text == "hello there")
        {
            message.Text += "."; // Append a period
        }
    }
*/
}
}