using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    private static int maxEvent;
    private static List<string> eventNames;
    private static int eventCount;

    // Start is called before the first frame update
    void Start()
    {
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
