using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


namespace DIALOGUE
{
    public class DialogueParser
    {
        public const string commandRegexPattern = "\\w*[^\\s]\\(";
        public static DIALOGUE_LINE Parse(string rawLine)
        {
            (string speaker, string dialogue, string commands) = RipContent(rawLine);
            
            return new DIALOGUE_LINE(speaker, dialogue, commands);
        }

        private static (string, string, string) RipContent(string rawLine)
        {
            string speaker = "", dialogue = "", commands = "";
            
            int dialogueStart = -1;
            int dialogueEnd = -1;
            bool isEscaped = false;

            for (int i = 0; i < rawLine.Length; i++)
            {
                char currentChar = rawLine[i];

                if (isEscaped)
                {
                    isEscaped = false;
                    continue;
                }

                if (currentChar == '"')
                {
                    if (dialogueStart == -1)
                    {
                        dialogueStart = i;
                        continue;
                    }
                    else
                    {
                        dialogueEnd = i;
                        break;
                    }
                }
                
                if (currentChar == '\\')
                    isEscaped = true;
                else
                    isEscaped = false;

                
                
            }
            // Identify Command Pattern
            
            
            
            // Debug.Log();
            Regex commandRegex = new Regex(commandRegexPattern);
            Match match = commandRegex.Match(rawLine);

            int commandStart = -1;

            if (match.Success)
            {
                commandStart = match.Index;

                if (dialogueStart != -1)
                {
                    if (commandStart < dialogueStart)
                    {
                        dialogueStart = -1;
                        dialogueEnd = -1;
                    }
                }
            }


            if (dialogueStart != -1)
                dialogue = rawLine.Substring(dialogueStart + 1, dialogueEnd - dialogueStart - 1);
            else
                dialogue = "";

            if (match.Success)
                commands = rawLine.Substring(commandStart, rawLine.Length - commandStart);
            else
                commands = "";

            if (dialogueStart != -1 && dialogueStart != 0)  // Dialogue Exists and Speaker Exists
                speaker = rawLine.Substring(0, dialogueStart-1);
            else if (match.Success && commandStart != 0) // Commands Exist and Speaker Exists
                speaker = rawLine.Substring(0, commandStart-1);
            else if (!match.Success && dialogueStart == -1) // Dialogue and Command Doesn't Exist.
                speaker = rawLine;
            
            dialogue = dialogue.Replace("\\\"", "\"");
            
            Debug.Log($"Speaker: {speaker.Trim()}");
            Debug.Log($"Dialogue: {dialogue.Trim()}");
            Debug.Log($"Commands: {commands.Trim()}");
            
            return (speaker.Trim(), dialogue.Trim(), commands.Trim());
        }
        

    }

}   