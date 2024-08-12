using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DIALOGUE
{
    public class ConversationManager
    {
        
        private DialogueSystem dialogueSystem => DialogueSystem.instance;
        private Coroutine process = null;
        public bool isRunning => process != null;
        

        public void StartConversation(List<string> conversation)
        {
            StopConversation();
            
            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));

        }

        public void StopConversation()
        {
            if (!isRunning)
                return;
            
            dialogueSystem.StopCoroutine(process);
            process = null;





        }

        IEnumerator RunningConversation(List<string> conversation)
        {
            for (int i = 0; i < conversation.Count; i++)
            {   
                
                if (conversation[i] == string.Empty)
                    continue;
                
                
                DIALOGUE_LINE line = DialogueParser.Parse(conversation[i]);

                if (line.hasDialogue)
                {
                    
                }
                
                
            }
        }
        
    }
}
 
