using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//data를 parsing하는 역할
public class DialogueParser : MonoBehaviour
{
    public Dialogue2[] Parse(string _CSVFileName)
    {
        List<Dialogue2> dialogueList = new List<Dialogue2>(); //대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //Resources파일에서 TextAsset으로 편환해서 csv파일 가져옴.
        
        string[] data = csvData.text.Split(new char[] { '\n' }); //한줄씩 쪼개서 data에 넣음
        for (int i = 1; i < data.Length;)
        {
            //Debug.Log(data[i]);
            string[] row = data[i].Split(new char[] { ',' }); //id, 캐릭터, 대사로 쪼갬

            /*
            Debug.Log(row[0]);
            Debug.Log(row[1]);
            Debug.Log(row[2]);
            */

            Dialogue2 dialogue = new Dialogue2(); //대사 리스트 생성

            dialogue.name = row[1]; //캐릭터 이름
            //Debug.Log(row[1]);

            //dialogue.contexts = row[2]; //대사 (배열 크기 지정없이 바로 대입 불가능 -> 리스트 사용)
            List<string> contextList = new List<string>();

            //최초 1회 조건비교없이 무조건 실행(캐릭터 이름이 비었을 경우 처리를 위해) for 대사 추가
            do
            {
                contextList.Add(row[2]); //대사 추가
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else //i가 데이터 길이보다 커지는 경우
                {
                    break;
                }
            } while (row[0].ToString() == ""); //ID가 여백일 경우 대사만 한 줄 더 추가          

            dialogue.contexts = contextList.ToArray(); //대사를 배열에 넣어줌

            dialogueList.Add(dialogue); //'이름-대사'가 묶여서 dialogueList에 저장
        }

        return dialogueList.ToArray();
    }
}
