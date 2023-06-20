using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// DialogueParse.cs
/// SceneManage�� ����
/// �ܺ� csv ������ �Ľ�
/// �Ľ��� ������ ����
/// GetDialogue�Լ��� �Ľ��� ��ȭ������ eventName ������ ����

[System.Serializable]
public class DebugTalkData
{
    public string eventName;
    public TalkData[] talkDatas;

    public DebugTalkData(string name, TalkData[] td)
    {
        eventName = name;
        talkDatas = td;
    }
}

public class DialogueParse : MonoBehaviour
{
    private void Awake()
    {
        SetTalkDictionary();
        SetDebugTalkData();
    }

    private static Dictionary<string, TalkData[]> TalkDictionary =
        new Dictionary<string, TalkData[]>();
    [SerializeField] private TextAsset csvFile = null;

    [SerializeField] List<DebugTalkData> DebugTalkDataList =
        new List<DebugTalkData>();


    public void SetTalkDictionary()
    {
        // �� �Ʒ� �� �� ����
        string csvText = csvFile.text.Substring(0, csvFile.text.Length - 1);
        // �ٹٲ��� �������� csv������ �ɰ��� string�迭�� ����
        string[] rows = csvText.Split(new char[] { '\n' });

        for (int i = 1; i < rows.Length; i++)
        {
            string[] rowValues = rows[i].Split(new char[] { ',' });

            if (rowValues[0].Trim() == "" || rowValues[0].Trim() == "end") continue;

            string eventName = rowValues[0];
            TalkData[] talkDatas = GetTalkDatas(rows, rowValues, ref i);

            TalkDictionary.Add(eventName, talkDatas);
        }
    }

    TalkData[] GetTalkDatas(string[] rows, string[] rowValues, ref int index)
    {
        List<TalkData> talkDataList = new List<TalkData>();

        while(rowValues[0].Trim() != "end")
        {
            List<string> contextList = new List<string>();

            TalkData talkData;
            talkData.name = rowValues[1];

            do
            {
                contextList.Add(rowValues[2].ToString());
                if (++index < rows.Length)
                    rowValues = rows[index].Split(new char[] { ',' });
                else break;
            } while (rowValues[1] == "" && rowValues[0] != "end");

            talkData.contexts = contextList.ToArray();
            talkDataList.Add(talkData);
        }

        return talkDataList.ToArray();
    }

    void SetDebugTalkData()
    {
        List<string> eventNames =
            new List<string>(TalkDictionary.Keys);
        List<TalkData[]> talkDataList =
            new List<TalkData[]>(TalkDictionary.Values);

        for(int i = 0; i < eventNames.Count; i++)
        {
            DebugTalkData debugTalk =
                new DebugTalkData(eventNames[i], talkDataList[i]);

            DebugTalkDataList.Add(debugTalk);
        }
    }

    public static TalkData[] GetDialogue(string eventName)
    {
        if(TalkDictionary.ContainsKey(eventName))
            return TalkDictionary[eventName];
        else
        {
            Debug.LogWarning("ã�� �� ���� �̺�Ʈ �̸�: " + eventName);
            return null;
        }
    }

    public static List<string> GetEventNames()
    {
        return new List<string>(TalkDictionary.Keys);
    }
}
