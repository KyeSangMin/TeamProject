using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    // 한 캐릭터가 가지는 최대 이벤트 수 -> 모든 캐릭터가 동일한 이벤트 수를 가져야 함.
    // 예를 들어 한 캐릭터가 20개의 이벤트를 가진다면 다른 모든 캐릭터도 20개의 이벤트를 가지고 있어야 함.
    private static int maxEvent;
    private static List<string> eventNames;

    // Start is called before the first frame update
    void Start()
    {
        // 초기화, maxEvent의 수정이 필요하면 여기서 하면 됩니다.
        maxEvent = 25;
        eventNames = DialogueParse.GetEventNames();
    }

    /// 이벤트 활성화
    /// npc 상호작용 이벤트는 mouseControl에서 이 함수로 제어하면 되고,
    /// 고정 이벤트는 고정 이벤트를 활성화하는 조건문을 가진 스크립트에서 이 함수를 이용해 제어하면 된다.
    /// NPC 상호작용 이벤트: (각 NPC ID) + (event index => 0 ~ 24)
    /// 0: 인사말, 1: 반복 대사, 2~21: 아이템별 상호작용 대사, 22~24: 확장가능공간(이벤트 추가시 사용)
    /// 고정 이벤트: (NPC ID = 0으로 고정) + (event index => 250 ~ 255)
    /// 250~255: 고정 이벤트 인덱스(연락, 차장실에서 설명충 on, 맞췄을때, 못맞췄을때)
    public void EnableEvent(int NPC_ID, int eventIndex)
    {
        gameObject.GetComponent<ChatBubbleManager>().currentEvent 
            = eventNames[NPC_ID * maxEvent + eventIndex];
    }
}
