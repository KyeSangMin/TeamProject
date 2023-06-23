using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// ChatBubbleManager.cs
/// SceneMangage�� ����
/// �̺�Ʈ�� ���� ��ǳ���� ����� ����

public class ChatBubbleManager : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    private Vector3 defaultPos = new Vector3(1.7f, 0.75f, 1.0f);
    private Vector3 defaultRightPos = new Vector3(1.2f, 1.5f, 1.0f);
    private Vector3 defaultLeftPos = new Vector3(-1.2f, 1.5f, 1.0f);

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

                case "����":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        Transform target = GameObject.Find("NPC_8").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_4").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_1").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, new Vector3(-2.35f, 3.0f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, new Vector3(2.35f, 3.0f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_2").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_3").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_9").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_5").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_11").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_10").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
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
                        Transform target = GameObject.Find("NPC_7").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, defaultLeftPos, talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, defaultRightPos, talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "�ܺ���":
                    Transform outsiderSpriteTransform = GameObject.Instantiate(GameAssets.i.pfOutsiderSprite, playerTransform);
                    outsiderSpriteTransform.localPosition = new Vector3(-2.0f, 0.25f, 1.0f);
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, new Vector3(0.0f, 1.5f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    Destroy(outsiderSpriteTransform.gameObject);
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
