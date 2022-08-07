using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogue; //Dialogue2.cs에서 만든 DialogueEvent 배열을 가져옴

    //databaseManager에 저장된 실제 데이터 스크립트를 꺼내와야 함.(StartNum,EndNum 지정)
    public Dialogue2[] GetDialogue()
    {
        //dialogues는 Dialogue2에서 만든 배열 
        //Vector2의 x,y를 활용해서 StartNum,EndNum지정 - Vector는 float값이 default므로 int로 강제형변환
        dialogue.dialogues = DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);
        return dialogue.dialogues;
    }
}
