using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharData : MonoBehaviour
{


    public int CharNumber;
    public int CharEvent;

    public List<int> CorrectList;
    
    /// CharEvent: ĳ���� �̺�Ʈ �ѹ�
    /// ĳ���ͺ��� ������ �̺�Ʈ �ѹ����� ���� �� ������ ����
    /// 0: �λ縻, 1: �ݺ� ���, 2~21: �����ۺ� ��ȣ�ۿ� ���, 22~24: Ȯ�尡�ɰ���(�̺�Ʈ �߰��� ���)

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
