using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharData : MonoBehaviour
{


    public int CharNumber;
    public int CharEvent;
    /// CharEvent: 캐릭터 이벤트 넘버
    /// 캐릭터별로 지정된 이벤트 넘버링을 지정 및 정보를 저장
    /// 0: 인사말, 1: 반복 대사, 2~21: 아이템별 상호작용 대사, 22~24: 확장가능공간(이벤트 추가시 사용)

    // Start is called before the first frame update
    void Start()
    {
        CharEvent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNumber()
    {
        return CharNumber;
    }

    public int FirstContect()
    {
        return CharEvent++;
    }

    public void CallEvent(int eventNum)
    {
        CharEvent = eventNum;
    }

    public void EndEvent()
    {
        CharEvent = 1;
    }
}
