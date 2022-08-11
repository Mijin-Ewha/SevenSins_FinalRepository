using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue dialogue;
    //public Dialogue2[] dialogue;
    
    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager2>().ShowDialogue(gameObject.GetComponent<InteractionEvent>().GetDialogue());
    }
}
