using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogue; //Dialogue2.cs���� ���� DialogueEvent �迭�� ������

    //databaseManager�� ����� ���� ������ ��ũ��Ʈ�� �����;� ��.(StartNum,EndNum ����)
    public Dialogue2[] GetDialogue()
    {
        //dialogues�� Dialogue2���� ���� �迭 
        //Vector2�� x,y�� Ȱ���ؼ� StartNum,EndNum���� - Vector�� float���� default�Ƿ� int�� ��������ȯ
        dialogue.dialogues = DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);
        return dialogue.dialogues;
    }
}
