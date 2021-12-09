using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatWindow : MonoBehaviour
{
    public Command[] commands; //Commands like emotes or utilities
    public ChatCommand[] chatCommands; //Commands that change how user uses the chat
    
    [Header("Components")] public TMP_InputField playerInput;
    public TextMeshProUGUI chatText;
    public TextMeshProUGUI targetText; 
    public Scrollbar chatScrollbar;

    [Header("Events")] public VoidEvent onChatSelected;
    public VoidEvent onChatDeselected;
    public VoidEvent onStartWritingChat;

    private string chatContent; //String that contains the chat content
    private string newChat;

    private bool commandFound;

    private chatType currentChatType; 

    public enum chatType
    {
        Say, 
        Group,
        Yell
    }

    private void Update()
    {
        if (Input.GetKeyDown(PlayerInput.commandButtons[1]))
            onStartWritingChat.Invoke(); //If specified button is pressed, start typing in chat window
    }

    public void Chat()
    {
        if (playerInput.text == "")
            return;
        
        CheckCommandLines(); //Checks for '/', if found, checks through list of commands
        
        if (!commandFound)
        {
            chatContent += chatContent != null ? "\n" : "";

            switch (currentChatType)
            {
                case chatType.Say:
                    Say();
                    break;

                case chatType.Group:
                    Group();
                    break;

                case chatType.Yell:
                    Yell(); 
                    break;
            }

            chatContent += newChat;
            chatText.text = chatContent;

            playerInput.text = "";
            chatScrollbar.value = 0;
        }
        else
            commandFound = false; 
    }

    public void Say() //Saying something that everyone can see
    {
        newChat = "<color=#A48853>[" + PlayerEntity.playerName + "]" + "says: " + playerInput.text;
    }

    public void Group() //Telling the group something
    {
        newChat = "<color=#00E3D1>[" + PlayerEntity.playerName + "]" + "tells the group: " + playerInput.text;
    }

    public void Yell() //Yelling something out loud that is seen across greater distances
    {
       newChat = "<color=#FF3F00>[" + PlayerEntity.playerName + "]" + "yells: " + playerInput.text;
    }

    public void SystemChat(string message)
    {
        chatContent += chatContent != null ? "\n" : "";
        string newChat = "<color=#E74113>" + message;
        chatContent += newChat;
        chatText.text = chatContent;
        chatScrollbar.value = 0; 
    }

    public void CheckCommandLines()
    {
        if (playerInput.text[0] == '/')
        {
            //Go through all commands and check if any matches with the input
            //If any match is found, invoke command event

            if (commands.Length > 0)
            {
                foreach (Command command in commands)
                {
                    if (command.commandLine == playerInput.text)
                    {
                        command.executionEvent.Invoke();
                        playerInput.text = null;
                        commandFound = true;
                        return;
                    }
                }
            }

            if (chatCommands.Length > 0)
            {
                foreach (ChatCommand chatCommand in chatCommands)
                {
                    if (chatCommand.commandLine == playerInput.text)
                    {
                        switch (chatCommand.chatType)
                        {
                            case("say") : SwitchChatType(chatType.Say, "<color=#A48853>Say");
                                break; 
                            case("group") : SwitchChatType(chatType.Group, "<color=#00E3D1>Group");
                                break;
                            case ("yell") : SwitchChatType(chatType.Yell, "<color=#FF3F00>Yell");
                                break; 
                        }
                        commandFound = true;
                        return;
                    }
                }
            }
        }
        else
            return;
    }

    public void SwitchChatType(chatType type, string targetString)
    {
        currentChatType = type;
        targetText.text = targetString;
        playerInput.text = null; 
    }

    public void OnSelected()
    {
        onChatSelected.Invoke();
    }

    public void OnDeselected()
    {
        onChatDeselected.Invoke();
    }
}