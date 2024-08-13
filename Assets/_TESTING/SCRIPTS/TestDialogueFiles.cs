using DIALOGUE;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestDialogueFiles : MonoBehaviour
    {
        [SerializeField] private TextAsset fileToRead = null;
        
        // Start is called before the first frame update
        void Start()
        {
            StartConversation();
        }

        // Update is called once per frame
        void StartConversation()
        {
            List<string> lines = FileManager.ReadTextAsset(fileToRead);

            
            DialogueSystem.instance.Say(lines);
        }
    }
}