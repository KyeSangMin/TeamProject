using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    // �� ĳ���Ͱ� ������ �ִ� �̺�Ʈ �� -> ��� ĳ���Ͱ� ������ �̺�Ʈ ���� ������ ��.
    // ���� ��� �� ĳ���Ͱ� 20���� �̺�Ʈ�� �����ٸ� �ٸ� ��� ĳ���͵� 20���� �̺�Ʈ�� ������ �־�� ��.
    private static int maxEvent;
    private static List<string> eventNames;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ�ȭ, maxEvent�� ������ �ʿ��ϸ� ���⼭ �ϸ� �˴ϴ�.
        maxEvent = 25;
        eventNames = DialogueParse.GetEventNames();
    }

    /// �̺�Ʈ Ȱ��ȭ
    /// npc ��ȣ�ۿ� �̺�Ʈ�� mouseControl���� �� �Լ��� �����ϸ� �ǰ�,
    /// ���� �̺�Ʈ�� ���� �̺�Ʈ�� Ȱ��ȭ�ϴ� ���ǹ��� ���� ��ũ��Ʈ���� �� �Լ��� �̿��� �����ϸ� �ȴ�.
    /// NPC ��ȣ�ۿ� �̺�Ʈ: (�� NPC ID) + (event index => 0 ~ 24)
    /// 0: �λ縻, 1: �ݺ� ���, 2~21: �����ۺ� ��ȣ�ۿ� ���, 22~24: Ȯ�尡�ɰ���(�̺�Ʈ �߰��� ���)
    /// ���� �̺�Ʈ: (NPC ID = 0���� ����) + (event index => 250 ~ 255)
    /// 250~255: ���� �̺�Ʈ �ε���(����, ����ǿ��� ������ on, ��������, ����������)
    public void EnableEvent(int NPC_ID, int eventIndex)
    {
        gameObject.GetComponent<ChatBubbleManager>().currentEvent 
            = eventNames[NPC_ID * maxEvent + eventIndex];
    }
}
