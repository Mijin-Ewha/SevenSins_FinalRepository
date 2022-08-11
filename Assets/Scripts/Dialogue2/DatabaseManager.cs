using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance; 

    [SerializeField] string csv_FileName;

    Dictionary<int, Dialogue2> dialogueDic = new Dictionary<int, Dialogue2>(); 

    public static bool isFinish = false; 

    void Awake() {
        if(instance == null){
            instance = this; 
            DialogueParser theParser = GetComponent<DialogueParser>();
            Dialogue2[] dialogues = theParser.Parse(csv_FileName); 
            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;
        }
    }

    public Dialogue2[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<Dialogue2> dialogueList = new List<Dialogue2>();

        for(int i = 0; i <= _EndNum-_StartNum; i++)
        {
            dialogueList.Add(dialogueDic[_StartNum+i]);
        }

        return dialogueList.ToArray();
    }
}
