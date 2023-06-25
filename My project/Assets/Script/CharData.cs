using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharData : MonoBehaviour
{


    public int CharNumber;
    public int CharEvent;

    public List<int> CorrectList;
    
    /// CharEvent: 캐릭터 이벤트 넘버
    /// 캐릭터별로 지정된 이벤트 넘버링을 지정 및 정보를 저장
    /// 0: 인사말, 1: 반복 대사, 2~21: 아이템별 상호작용 대사, 22~24: 확장가능공간(이벤트 추가시 사용)

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.isFirst[CharNumber - 1])
            CharEvent = 0;
        else
            CharEvent = 1;
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
        DataManager.isFirst[CharNumber - 1] = false;
        return CharEvent++;
    }

    public void CallEvent(int eventNum)
    {
        CharEvent = eventNum;
    }

    public void EndEvent()
    {
        if (DataManager.isFirst[CharNumber - 1])
            CharEvent = 0;
        else
            CharEvent = 1;
    }

   
}
