using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// ChatBubbleManager.cs
/// SceneMangage�� ����
/// �̺�Ʈ�� ���� ��ǳ���� ����� ����

public class ChatBubbleManager : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    private Vector3 defaultPos = new Vector3(1.2f, 0.5f, 1.0f);

    // ���� �߻��� �̺�Ʈ�̸�
    private string _currentEvent;
    public string currentEvent 
    {
        get { return _currentEvent; }
        set { _currentEvent = value; }
    }

    // ��ȭ ��ũ��Ʈ�� �ε��� ����
    private int dataCount = 0;
    private int contextCount = 0;

    // ��ȭ�� �����Ͽ��°� -> ��ǥ NPC�� Ŭ���� �� true
    public static bool isTalking = false;
    // ��ǳ���� �����ϴ°� -> ��ǳ���� Ŭ���� destroy�Ǹ� false, �����ϰ� ������ �׻� true
    public static bool isChat = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextDialogue("�ܺο��� ����"));
    }

    // Update is called once per frame
    void Update()
    {
        // ��ȭ ���� ���̰� ��ǳ���� ���ٸ�
        if (isTalking && !isChat)
        {
            isTalking = false;                  // ���ѷ��� ����
            StartCoroutine(NextDialogue(_currentEvent));   // ��ȭ�� ����
        }
        // ��ȭ�� �����ϰ� �ٽ� npc�� Ŭ������ ��
        else if (isTalking) isTalking = false;
    }

    IEnumerator NextDialogue(string eventName)
    {
        TalkData[] talkDatas = DialogueParse.GetDialogue(eventName);

        while (dataCount < talkDatas.Length)
        {
            // ��ȭ ��ũ��Ʈ�� �ι��̸��� �ϴ��ϸ�Ī
            switch (talkDatas[dataCount].name)
            {
                case "���ΰ�":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "�ϸ�Ʈ��":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(GameObject.Find("NPC_4").transform, new Vector3(1.1f, 1.4f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "���ٽ���":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "��������":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(GameObject.Find("NPC_3").transform, new Vector3(1.1f, 1.4f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "�Ͻ�":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(GameObject.Find("NPC_2").transform, new Vector3(1.3f, 2.5f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "�ٴϿ�":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "����":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "��":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "Ÿ��":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "��":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "���̺��":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "����":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, defaultPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "�ܺ���":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, new Vector3(-1.2f, 0.8f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                default:
                    dataCount++;
                    break;
            }
        }

        dataCount = 0;
        contextCount = 0;
    }
}
