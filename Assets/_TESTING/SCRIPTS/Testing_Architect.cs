using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;
        
        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
        
        
        
        string[] lines = new string[5]
        {
            "Moth-senpai's curves were as captivating as the sunset, making my heart race uncontrollably.",
            "I fumbled with my keys, blushing furiously as I imagined Moth-chan's soft touch on my hand.",
            "The clock tower's chimes reminded me of the passionate nights spent with Moth-sama.",
            "A breeze lifted Moth-chan's skirt slightly, revealing a tantalizing glimpse that left me breathless.",
            "In the shadows, Moth-kun's eyes smoldered with desire, making my knees weak with anticipation."
        };

        
        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architect.speed = 0.5f;


        }

        // Update is called once per frame
        void Update()
        {
            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
            }
            
            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                } else
                {
                    architect.Build(lines[Random.Range(0, lines.Length)]);

                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
}

