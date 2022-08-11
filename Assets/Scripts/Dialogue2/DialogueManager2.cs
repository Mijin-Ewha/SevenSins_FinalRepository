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

    bool isDialogue = false; //��ȭ������ ����
    bool isNext = false; //for ���� ��� ���

    [Header("�ؽ�Ʈ ��� ������")]
    [SerializeField] float textDelay;

    int lineCount=0; //��ȭ ī��Ʈ(ĳ���� ����)
    int contextCount=0; //��� ī��Ʈ

    //�����̽��� �Է� �� ���� ��ȭ�� �Ѿ
    /*
    public void Update(){
        if(isDialogue){
            if(isNext){
                if(Input.GetKeyDown(KeyCode.Space)){ //�����̽��� �Է� �� ����
                    isNext = false;
                    txt_Dialogue.text = "";

                    //���� ĳ������ ��簡 ������ ���� ��쿡��
                    if(++contextCount<dialogues[lineCount].contexts.Length){
                        StartCoroutine(TypeWriter());
                    } else { //���� ĳ���� ���
                        contextCount=0;
                        if(++lineCount<dialogues.Length){ //�� ��ȭ �������� ���� ��쿡��
                            StartCoroutine(TypeWriter());
                        } else { //��ȭ�� ���� ���
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }
    */

    //������� (onClick - DialogueBox)
    public void DisplayNextSentence(){
        if(isDialogue){ 
            if(isNext) {
                isNext = false;
                txt_Dialogue.text="";

                //���� ĳ������ ��簡 �����ִ� ���
                if(++contextCount<dialogues[lineCount].contexts.Length){
                    StartCoroutine(TypeWriter());
                } else { //���� ĳ���� ���
                    contextCount=0;
                    if(++lineCount<dialogues.Length){ //�� ��ȭ �������� ���� ��쿡��
                        StartCoroutine(TypeWriter());
                    } else { //��ȭ�� ���� ���
                        EndDialogue();
                    }
                }
            }
        }
    }

    public void ShowDialogue(Dialogue2[] p_dialogues)
    {
        isDialogue = true; //��ȭ ���� �� isDialogue = true
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());
        //DisplayNextSentence2();   
    }

    void EndDialogue(){
        isDialogue = false; //��ȭ ����
        contextCount=0;
        lineCount=0;
        dialogues=null;
        isNext=false;
        DialogueBox.SetBool("IsOpen", false); //��ȭ UI ǥ��X
    }

    //animator 3�� �̻� ����ϸ� ���� -> ���� �ʿ�
    IEnumerator TypeWriter(){
        DialogueBox.SetBool("IsOpen", true); //��ȭ UI ǥ��

        if(dialogues[lineCount].name==""){//�ý���
            UserNameBox.SetBool("OnUser", false); //���ΰ� UI ǥ��X
            NameBox.SetBool("OnName", false);  //ĳ���� namebarX

        } else if(dialogues[lineCount].name=="���ΰ�"){ //���ΰ�
            txt_Name.text = dialogues[lineCount].name; //ĳ���� �̸� ����
            //DialogueBox.SetBool("IsOpen", true); //��ȭ UI ǥ��
            NameBox.SetBool("OnName", false);  //ĳ���� namebarX
            UserNameBox.SetBool("OnUser", true); //���ΰ� UI ǥ��

        } else { //����X(ĳ����)
            //DialogueBox.SetBool("IsOpen", true); //��ȭ UI ǥ��
            UserNameBox.SetBool("OnUser", false);
            NameBox.SetBool("OnName", true);
            txt_Name.text = dialogues[lineCount].name;
        }

        // from ` to ,
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount]; 
        t_ReplaceText = t_ReplaceText.Replace("`",",");
        t_ReplaceText = t_ReplaceText.Replace("\\n","\n");

        txt_Dialogue.text = t_ReplaceText; //�ٲ� �� ���� or text delay

        yield return null;

        /* text delay -> ��� ���� ��!!�ФФ�
        //bool t_white = false, t_yellow = false;
        //bool t_ignore = false; //for Ư������ ��� ����

        for(int i=0;i<t_ReplaceText.Length;i++){
            switch(t_ReplaceText[i]){
                case '��' : t_white = true; t_yellow=false; t_ignore=true; break;
                case '��' : t_white = false; t_yellow=true; t_ignore=true; break;
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
        isNext = true; //���� ����� �����ϵ��� true�� = ���� �� �Է� ����
    }
}
