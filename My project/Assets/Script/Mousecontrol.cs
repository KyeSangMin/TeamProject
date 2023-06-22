using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mousecontrol : MonoBehaviour
{
    // Start is called before the first frame update



    GameObject sound;
    bool SetCamera;
    public bool GetItem;
    GameObject ScanInfo;
    //GameObject UiPad;
    DialogueEvent dialogueEvent;

    //bool ScanActive;
    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<CRTEffect>().enabled = false;
        dialogueEvent = gameObject.GetComponent<DialogueEvent>();

        //UiPad = GameObject.Find("MainUI").GetComponent<UI_ButtonEvent>();
        ScanInfo = GameObject.Find("'ScanInfo");
        sound = GameObject.Find("AudioManager");
        SetCamera = false;
        GetItem = false;
        //ScanActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;


            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);


            if(hit.collider != null && !GameObject.Find("MainUI").GetComponent<UI_ButtonEvent>().UiSetUp)
            {

                if(GetItem)
                {
                    if (hit.collider.CompareTag("NPC"))
                    {

                        CharData target = hit.collider.GetComponent<CharData>();
                        switch (GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList)
                        {
                            case int n when (n >= 1 && n <= 20):
                                GetItem = false;
                                target.CallEvent(GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList+1);
                                break;

                            default:
                                break;
                        }
                        switch (target.CharEvent)
                        {
                            // 0: �λ縻, 1: �ݺ� ���, 2~21: �����ۺ� ��ȣ�ۿ� ���, 22~24: Ȯ�尡�ɰ���(�̺�Ʈ �߰��� ���)
                            // 250~255: ���� �̺�Ʈ �ε���(����, ����ǿ��� ������ on, ��������, ����������)
                            case 0:
                                // npc�� Ŭ���ϸ� npc�� ������ȣ�� eventManager(= DialogueEvent)�� ����
                                dialogueEvent.EnableEvent(target.getNumber() + 1, target.FirstContect());
                                ChatBubbleManager.isTalking = true;
                                break;

                            case 1:
                            case int n when (n >= 2 && n <= 24):
                                dialogueEvent.EnableEvent(target.getNumber() + 1, target.CharEvent);
                                ChatBubbleManager.isTalking = true;
                                target.EndEvent();
                                break;

                            case int n when (n >= 250 && n <= 255):
                                dialogueEvent.EnableEvent(0, target.CharEvent);
                                ChatBubbleManager.isTalking = true;
                                target.EndEvent();
                                break;

                            default:
                                dialogueEvent.EnableEvent(target.getNumber() + 1, 1);
                                ChatBubbleManager.isTalking = true;
                                break;
                        }
                    }
                    else
                    {
                        GetItem = false;
                        Debug.Log("false");
                    }

                    if (hit.collider.CompareTag("ChatBubble"))
                    {
                        ChatBubbleManager.isChat = false;
                        Destroy(GameObject.FindWithTag("ChatBubble"));
                    }

                }
                else
                {
                    if (SetCamera == true)
                    {

                        if (hit.collider.CompareTag("ScanItem"))
                        {
                            sound.GetComponent<SoundManager>().PlayEffect(1);
                            //GameObject.Find("Main Camera").GetComponent<FollowCam>().ShakeTime = 0.5f;

                            GameObject.Find("MainUI").GetComponent<NoiseEffect>().StartNose(0.1f);
                            hit.collider.gameObject.GetComponent<ScanItem>().ClickItem();
                            hit.collider.gameObject.SetActive(false);

                        }

                        if (hit.collider.CompareTag("UnuseScan"))
                        {
                            sound.GetComponent<SoundManager>().PlayEffect(1);
                            //GameObject.Find("Main Camera").GetComponent<FollowCam>().ShakeTime = 0.5f;
                            GameObject.Find("MainUI").GetComponent<NoiseEffect>().StartNose(0.1f);
                            ScanInfo.GetComponent<UnuseScanItem>().ActiveItemInfo();
                            //hit.collider.gameObject.SetActive(false);
                        }

                    }
                    else
                    {
                        if (hit.collider.CompareTag("RightPoint"))
                        {
                            GameObject.Find("SceneManage").GetComponent<DataManager>().CheckDoor();
                            //sound.GetComponent<SoundManager>().PlayEffect(2);
                            //GameObject.Find("SceneManage").GetComponent<SceneManage>().NextSceneLoad(SceneManage.SceneNum);
                        }
                        if (hit.collider.CompareTag("LeftPoint"))
                        {
                            sound.GetComponent<SoundManager>().PlayEffect(2);
                            GameObject.Find("SceneManage").GetComponent<SceneManage>().BeforeSceneLoad(SceneManage.SceneNum);
                        }
                        if (hit.collider.CompareTag("Item"))
                        {
                            sound.GetComponent<SoundManager>().PlayEffect(1);
                            hit.collider.gameObject.GetComponent<ScanItem>().ClickItem();
                            hit.collider.gameObject.SetActive(false);

                        }
                        if (hit.collider.CompareTag("NPC"))
                        {
                            CharData target = hit.collider.GetComponent<CharData>();
                            sound.GetComponent<SoundManager>().PlayEffect(1);
                            GameObject.Find("SceneManage").GetComponent<DataManager>().AddCharInfo(hit.collider.GetComponent<CharData>().getNumber());


                            /// if(������ �ѹ� data�� ������ ��� or ���� �̺�Ʈ�� ������ ���)
                            //if (target.CharEvent == 0) target.CallEvent(10);    // ������ 9�� data �׽�Ʈ

                            switch (target.CharEvent)
                            {
                                // 0: �λ縻, 1: �ݺ� ���, 2~21: �����ۺ� ��ȣ�ۿ� ���, 22~24: Ȯ�尡�ɰ���(�̺�Ʈ �߰��� ���)
                                // 250~255: ���� �̺�Ʈ �ε���(����, ����ǿ��� ������ on, ��������, ����������)
                                case 0:
                                    // npc�� Ŭ���ϸ� npc�� ������ȣ�� eventManager(= DialogueEvent)�� ����
                                    dialogueEvent.EnableEvent(target.getNumber()+1, target.FirstContect());
                                    ChatBubbleManager.isTalking = true;
                                    break;

                                case 1:
                                case int n when (n >= 2 && n <= 24):
                                    dialogueEvent.EnableEvent(target.getNumber()+1, target.CharEvent);
                                    ChatBubbleManager.isTalking = true;
                                    target.EndEvent();
                                    break;

                                case int n when (n >= 250 && n <= 255):
                                    dialogueEvent.EnableEvent(0, target.CharEvent);
                                    ChatBubbleManager.isTalking = true;
                                    target.EndEvent();
                                    break;

                                default:
                                    dialogueEvent.EnableEvent(target.getNumber()+1, 1);
                                    ChatBubbleManager.isTalking = true;
                                    break;
                            }
                          


                        }
                        if (hit.collider.CompareTag("ChatBubble"))
                        {
                            ChatBubbleManager.isChat = false;
                            Destroy(GameObject.FindWithTag("ChatBubble"));
                        }

                        if (hit.collider.CompareTag("PuzzleExit"))
                        {
                            GameObject.Find("SceneManage").GetComponent<DataManager>().DestroyPuzzle();

                        }

                    }
                }
                
            }


        }

        if (Input.GetMouseButtonDown(1))
        {

           
            GameObject.Find("Main Camera").GetComponent<FollowCam>().ShakeTime = 0.5f;
            GameObject.Find("MainUI").GetComponent<NoiseEffect>().StartNose(0.1f);
           


            if (SetCamera == false)
            {
                GameObject.Find("Main Camera").GetComponent<CRTEffect>().enabled = true;
                SetCamera = true;
            }
            else
            {
                GameObject.Find("Main Camera").GetComponent<CRTEffect>().enabled = false;
                SetCamera = false;
            }
        }


        }



    
}
