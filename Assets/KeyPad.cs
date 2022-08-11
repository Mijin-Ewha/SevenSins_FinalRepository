using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyPad : MonoBehaviour
{

    public GameObject keypad08;
    //public GameObject hud;
    //public GameObject inv;

  
    //public Animator ANI;

    public Text text08;
    public string answer = "123456";

    //public AudioSource button;
    //public AudioSource correct;
    //public AudioSource wrong;

    public bool animate;

    private void Start()
    {
        
    }

    public void Number(int number)
    {
        text08.text += number.ToString();
        //button.Play();
        if (text08.text.Length > 6)
        {
            Debug.Log("´Ù½Ã");
            text08.text = "";
        }
    }

    public void Execute()
    {
        if(text08.text==answer)
        {
            //correct.Play();
            text08.text = "Right";
        }
        else
        {
            //wrong.Play();
            text08.text = "Wrong";
        }
    }

    public void Clear()
    {
        text08.text = "";
        //button.Play();
    }

    public void Exit()
    {
        keypad08.SetActive(false);
        //inv.SetActive(true);
        //hud.SetActive(true);
        
    }

    public void Update()
    {
        if(text08.text=="Right")
        {
            Debug.Log("right");
        }
    }



}
