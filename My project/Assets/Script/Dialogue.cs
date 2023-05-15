using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TalkData
{
    public string name;         // ��� ġ�� ĳ���� �̸�
    public string[] contexts;   // ��� ����
}

public class Dialogue : MonoBehaviour
{
    // ��ȭ �̺�Ʈ �̸�
    [SerializeField] string eventName = null;
    // ���� ������ TalkData �迭
    [SerializeField] TalkData[] talkDatas = null;

    public TalkData[] GetObjectDialogue()
    {
        return DialogueParse.GetDialogue(eventName);
    }
}
