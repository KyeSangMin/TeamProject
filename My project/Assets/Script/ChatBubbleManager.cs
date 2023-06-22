using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// ChatBubbleManager.cs
/// SceneMangage에 적용
/// 이벤트에 따른 말풍선의 출력을 제어

public class ChatBubbleManager : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    private Vector3 defaultPos = new Vector3(1.2f, 0.5f, 1.0f);
    private Vector3 defaultRightPos = new Vector3(0.9f, 1.2f, 1.0f);
    private Vector3 defaultLeftPos = new Vector3(-2.1f, 1.2f, 1.0f);

    // 현재 발생한 이벤트이름
    private string _currentEvent;
    public string currentEvent 
    {
        get { return _currentEvent; }
        set { _currentEvent = value; }
    }

    // 대화 스크립트의 인덱스 정보
    private int dataCount = 0;
    private int contextCount = 0;

    // 대화를 시작하였는가 -> 목표 NPC를 클릭할 시 true
    public static bool isTalking = false;
    // 말풍선이 존재하는가 -> 말풍선을 클릭해 destroy되면 false, 존재하고 있으면 항상 true
    public static bool isChat = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextDialogue("외부에서 접촉"));
    }

    // Update is called once per frame
    void Update()
    {
        // 대화 시작 전이고 말풍선이 없다면
        if (isTalking && !isChat)
        {
            isTalking = false;                  // 무한루프 방지
            StartCoroutine(NextDialogue(_currentEvent));   // 대화를 시작
        }
        // 대화를 시작하고 다시 npc를 클릭했을 때
        else if (isTalking) isTalking = false;
    }

    IEnumerator NextDialogue(string eventName)
    {
        TalkData[] talkDatas = DialogueParse.GetDialogue(eventName);

        while (dataCount < talkDatas.Length)
        {
            // 대화 스크립트의 인물이름을 일대일매칭
            switch (talkDatas[dataCount].name)
            {
                case "주인공":
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

                case "유나":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        Transform target = GameObject.Find("NPC_0").transform;

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

                case "다니엘":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        Transform target = GameObject.Find("NPC_1").transform;

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

                case "록시":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        Transform target = GameObject.Find("NPC_2").transform;

                        if (playerTransform.position.x < target.position.x)
                            ChatBubble.Create(target, new Vector3(-4.2f, 2.6f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
                        else
                            ChatBubble.Create(target, new Vector3(1.5f, 2.6f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
                        isChat = true;
                        yield return new WaitUntil(() => !isChat);
                        continue;
                    }
                    contextCount = 0;
                    dataCount++;
                    break;

                case "세르게이":
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

                case "하르트만":
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

                case "얼릭":
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

                case "현식":
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        Transform target = GameObject.Find("NPC_6").transform;

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

                case "김":
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

                case "데이비드":
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

                case "타로":
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

                case "외부인":
                    Transform outsiderSpriteTransform = GameObject.Instantiate(GameAssets.i.pfOutsiderSprite, playerTransform);
                    outsiderSpriteTransform.localPosition = new Vector3(-1.5f, 2.0f, 1.0f);
                    for (; contextCount < talkDatas[dataCount].contexts.Length;)
                    {
                        ChatBubble.Create(playerTransform, new Vector3(0.0f, 2.0f, 1.0f), talkDatas[dataCount].contexts[contextCount++]);
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
