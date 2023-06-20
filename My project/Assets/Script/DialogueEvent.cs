using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    // 한 캐릭터가 가지는 최대 이벤트 수 -> 모든 캐릭터가 동일한 이벤트 수를 가져야 함.
    // 예를 들어 한 캐릭터가 20개의 이벤트를 가진다면 다른 모든 캐릭터도 20개의 이벤트를 가지고 있어야 함.
    private static int maxEvent;
    private static List<string> eventNames;

    // 이벤트 진행도, 대화가 변화하는 조건을 달성한다면 1씩 증가한다.
    private static int eventCount;

    // Start is called before the first frame update
    void Start()
    {
        // 초기화, maxEvent의 수정이 필요하면 여기서 하면 됩니다.
        maxEvent = 0;
        eventCount = 2;
        eventNames = DialogueParse.GetEventNames();
    }

    public void EnableEvent(int NPC_ID)
    {
        gameObject.GetComponent<ChatBubbleManager>().currentEvent 
            = eventNames[NPC_ID * maxEvent + eventCount];
    }

    public void nextEvent(int next = 1)
    {
        eventCount += next;
    }
}
