using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//data�� parsing�ϴ� ����
public class DialogueParser : MonoBehaviour
{
    public Dialogue2[] Parse(string _CSVFileName)
    {
        List<Dialogue2> dialogueList = new List<Dialogue2>(); //��� ����Ʈ ����
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //Resources���Ͽ��� TextAsset���� ��ȯ�ؼ� csv���� ������.
        
        string[] data = csvData.text.Split(new char[] { '\n' }); //���پ� �ɰ��� data�� ����
        for (int i = 1; i < data.Length;)
        {
            //Debug.Log(data[i]);
            string[] row = data[i].Split(new char[] { ',' }); //id, ĳ����, ���� �ɰ�

            /*
            Debug.Log(row[0]);
            Debug.Log(row[1]);
            Debug.Log(row[2]);
            */

            Dialogue2 dialogue = new Dialogue2(); //��� ����Ʈ ����

            dialogue.name = row[1]; //ĳ���� �̸�
            //Debug.Log(row[1]);

            //dialogue.contexts = row[2]; //��� (�迭 ũ�� �������� �ٷ� ���� �Ұ��� -> ����Ʈ ���)
            List<string> contextList = new List<string>();

            //���� 1ȸ ���Ǻ񱳾��� ������ ����(ĳ���� �̸��� ����� ��� ó���� ����) for ��� �߰�
            do
            {
                contextList.Add(row[2]); //��� �߰�
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else //i�� ������ ���̺��� Ŀ���� ���
                {
                    break;
                }
            } while (row[0].ToString() == ""); //ID�� ������ ��� ��縸 �� �� �� �߰�          

            dialogue.contexts = contextList.ToArray(); //��縦 �迭�� �־���

            dialogueList.Add(dialogue); //'�̸�-���'�� ������ dialogueList�� ����
        }

        return dialogueList.ToArray();
    }
}
