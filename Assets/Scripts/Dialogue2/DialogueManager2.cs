using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for text

public class DialogueManager2 : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    [SerializeField] Animator DialogueBox;
    [SerializeField] Animator UserNameBox;
    [SerializeField] Animator NameBox;

    Dialogue2[] dialogues;

    bool isDialogue = false; //대화중인지 여부
    bool isNext = false; //for 다음 대사 출력

    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay;

    int lineCount=0; //대화 카운트(캐릭터 단위)
    int contextCount=0; //대사 카운트

    //스페이스바 입력 시 다음 대화로 넘어감
    /*
    public void Update(){
        if(isDialogue){
            if(isNext){
                if(Input.GetKeyDown(KeyCode.Space)){ //스베이스바 입력 시 다음
                    isNext = false;
                    txt_Dialogue.text = "";

                    //현재 캐릭터의 대사가 끝나지 않은 경우에만
                    if(++contextCount<dialogues[lineCount].contexts.Length){
                        StartCoroutine(TypeWriter());
                    } else { //다음 캐릭터 대사
                        contextCount=0;
                        if(++lineCount<dialogues.Length){ //총 대화 개수보다 작은 경우에만
                            StartCoroutine(TypeWriter());
                        } else { //대화가 끝난 경우
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }
    */

    //다음대사 (onClick - DialogueBox)
    public void DisplayNextSentence(){
        if(isDialogue){ 
            if(isNext) {
                isNext = false;
                txt_Dialogue.text="";

                //현재 캐릭터의 대사가 남아있는 경우
                if(++contextCount<dialogues[lineCount].contexts.Length){
                    StartCoroutine(TypeWriter());
                } else { //다음 캐릭터 대사
                    contextCount=0;
                    if(++lineCount<dialogues.Length){ //총 대화 개수보다 작은 경우에만
                        StartCoroutine(TypeWriter());
                    } else { //대화가 끝난 경우
                        EndDialogue();
                    }
                }
            }
        }
    }

    public void ShowDialogue(Dialogue2[] p_dialogues)
    {
        isDialogue = true; //대화 시작 시 isDialogue = true
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());
        //DisplayNextSentence2();   
    }

    void EndDialogue(){
        isDialogue = false; //대화 종료
        contextCount=0;
        lineCount=0;
        dialogues=null;
        isNext=false;
        DialogueBox.SetBool("IsOpen", false); //대화 UI 표시X
    }

    //animator 3개 이상 사용하면 느림 -> 개선 필요
    IEnumerator TypeWriter(){
        DialogueBox.SetBool("IsOpen", true); //대화 UI 표시

        if(dialogues[lineCount].name==""){//시스템
            UserNameBox.SetBool("OnUser", false); //주인공 UI 표시X
            NameBox.SetBool("OnName", false);  //캐릭터 namebarX

        } else if(dialogues[lineCount].name=="주인공"){ //주인공
            txt_Name.text = dialogues[lineCount].name; //캐릭터 이름 저장
            //DialogueBox.SetBool("IsOpen", true); //대화 UI 표시
            NameBox.SetBool("OnName", false);  //캐릭터 namebarX
            UserNameBox.SetBool("OnUser", true); //주인공 UI 표시

        } else { //독백X(캐릭터)
            //DialogueBox.SetBool("IsOpen", true); //대화 UI 표시
            UserNameBox.SetBool("OnUser", false);
            NameBox.SetBool("OnName", true);
            txt_Name.text = dialogues[lineCount].name;
        }

        // from ` to ,
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount]; 
        t_ReplaceText = t_ReplaceText.Replace("`",",");
        t_ReplaceText = t_ReplaceText.Replace("\\n","\n");

        txt_Dialogue.text = t_ReplaceText; //바꾼 거 저장 or text delay

        yield return null;

        /* text delay -> 출력 오류 남!!ㅠㅠㅠ
        //bool t_white = false, t_yellow = false;
        //bool t_ignore = false; //for 특수문자 출력 제외

        for(int i=0;i<t_ReplaceText.Length;i++){
            switch(t_ReplaceText[i]){
                case 'ⓦ' : t_white = true; t_yellow=false; t_ignore=true; break;
                case 'ⓨ' : t_white = false; t_yellow=true; t_ignore=true; break;
            }

            string t_letter = t_ReplaceText[i].ToString();

            if(!t_ignore){
                if(t_white){
                    //using html tag
                    t_letter = "<color=#ffffff>"+t_letter+"</color>";
                } else if(t_yellow){
                    t_letter = "<color=#ffff00>"+t_letter+"</color>";
                }
                txt_Dialogue.text += t_letter;
            }
            t_ignore = false;

           
            yield return new WaitForSeconds(textDelay);
        }
        */
        isNext = true; //다음 출력이 가능하도록 true로 = 다음 줄 입력 가능
    }
}
