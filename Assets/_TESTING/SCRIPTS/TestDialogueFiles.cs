using DIALOGUE;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestDialogueFiles : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartConversation();
        }

        // Update is called once per frame
        void StartConversation()
        {
            List<string> lines = FileManager.ReadTextAsset("testFile", false);

            DialogueSystem.instance.Say(lines);
        }
    }
}