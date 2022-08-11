using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //custom Ŭ������ inspector â���� �����ϱ� ���� �ʿ�
public class Dialogue2
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]
    public string name; //npc name

    [Tooltip("��� ����")]
    public string[] contexts;
}

//���� ���� ���ϹǷ� DialogueŬ������ �迭�� �������� ��
[System.Serializable]
public class DialogueEvent
{
    public string scene; //scene name = event name

    public Vector2 line; //x���� y������ ��縦 ����(x:start line, y:end line)
    public Dialogue2[] dialogues;
}