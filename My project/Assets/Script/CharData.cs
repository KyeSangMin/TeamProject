using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharData : MonoBehaviour
{


    public int CharNumber;
    public int CharEvent;
    private bool isFirst;
    /// CharEvent: ĳ���� �̺�Ʈ �ѹ�
    /// ĳ���ͺ��� ������ �̺�Ʈ �ѹ����� ���� �� ������ ����
    /// 0: �λ縻, 1: �ݺ� ���, 2~21: �����ۺ� ��ȣ�ۿ� ���, 22~24: Ȯ�尡�ɰ���(�̺�Ʈ �߰��� ���)

    // Start is called before the first frame update
    void Start()
    {
        CharEvent = 0;
        isFirst = true;
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
        isFirst = false;
        return CharEvent++;
    }

    public void CallEvent(int eventNum)
    {
        CharEvent = eventNum;
    }

    public void EndEvent()
    {
        if (isFirst)
            CharEvent = 0;
        else
            CharEvent = 1;
    }
}
