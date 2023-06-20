using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    // �� ĳ���Ͱ� ������ �ִ� �̺�Ʈ �� -> ��� ĳ���Ͱ� ������ �̺�Ʈ ���� ������ ��.
    // ���� ��� �� ĳ���Ͱ� 20���� �̺�Ʈ�� �����ٸ� �ٸ� ��� ĳ���͵� 20���� �̺�Ʈ�� ������ �־�� ��.
    private static int maxEvent;
    private static List<string> eventNames;

    // �̺�Ʈ ���൵, ��ȭ�� ��ȭ�ϴ� ������ �޼��Ѵٸ� 1�� �����Ѵ�.
    private static int eventCount;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ�ȭ, maxEvent�� ������ �ʿ��ϸ� ���⼭ �ϸ� �˴ϴ�.
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
