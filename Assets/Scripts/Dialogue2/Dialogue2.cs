using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //custom 클래스를 inspector 창에서 수정하기 위해 필요
public class Dialogue2
{
    [Tooltip("대사 치는 캐릭터 이름")]
    public string name; //npc name

    [Tooltip("대사 내용")]
    public string[] contexts;
}

//여러 명이 말하므로 Dialogue클래스를 배열로 만들어줘야 함
[System.Serializable]
public class DialogueEvent
{
    public string scene; //scene name = event name

    public Vector2 line; //x부터 y까지의 대사를 추출(x:start line, y:end line)
    public Dialogue2[] dialogues;
}