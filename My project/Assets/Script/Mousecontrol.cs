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
        ScanInfo = GameObject.Find("ScanInfo");
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
                                GameObject.Find("Button").GetComponent<ImageSwitch>().sprite = GameObject.Find("Button").GetComponent<ImageSwitch>().silhouette;
                                GameObject.Find("Button").GetComponent<ImageSwitch>().SwitchItemImage();
                                break;


                            default:
                                break;
                        }
                        switch (target.CharEvent)
                        {
                            // 0: 인사말, 1: 반복 대사, 2~21: 아이템별 상호작용 대사, 22~24: 확장가능공간(이벤트 추가시 사용)
                            // 250~255: 고정 이벤트 인덱스(연락, 차장실에서 설명충 on, 맞췄을때, 못맞췄을때)
                            case 0:
                                // npc를 클릭하면 npc의 고유번호가 eventManager(= DialogueEvent)로 전달
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
                        GameObject.Find("Button").GetComponent<ImageSwitch>().sprite = GameObject.Find("Button").GetComponent<ImageSwitch>().silhouette;
                        GameObject.Find("Button").GetComponent<ImageSwitch>().SwitchItemImage();
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
                        if (hit.collider.CompareTag("Retrun"))
                        {
                            sound.GetComponent<SoundManager>().PlayEffect(2);
                            GameObject.Find("SceneManage").GetComponent<SceneManage>().TeleportRetrun();
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


                            /// if(아이템 넘버 data가 존재할 경우 or 고정 이벤트가 존재할 경우)
                            //if (target.CharEvent == 0) target.CallEvent(10);    // 아이템 9번 data 테스트

                            switch (target.CharEvent)
                            {
                                // 0: 인사말, 1: 반복 대사, 2~21: 아이템별 상호작용 대사, 22~24: 확장가능공간(이벤트 추가시 사용)
                                // 250~255: 고정 이벤트 인덱스(연락, 차장실에서 설명충 on, 맞췄을때, 못맞췄을때)
                                case 0:
                                    // npc를 클릭하면 npc의 고유번호가 eventManager(= DialogueEvent)로 전달
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
                            sound.GetComponent<SoundManager>().PlayEffect(1);
                            GameObject.Find("SceneManage").GetComponent<DataManager>().DestroyPuzzle();

                        }
                        if (hit.collider.CompareTag("LockedDoor"))
                        {
                            sound.GetComponent<SoundManager>().PlayEffect(1);
                            hit.collider.gameObject.GetComponent<LockedDoorUIControl>().EnableLockedWindow();
                        }
                        if (hit.collider.CompareTag("Fisrt"))
                        {
                            Debug.Log("aa");
                            sound.GetComponent<SoundManager>().PlayEffect(2);
                            GameObject.Find("SceneManage").GetComponent<SceneManage>().TeleportRoom1();

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
                GameObject.Find("ScanInfo").GetComponent<UnuseScanItem>().offUnsedUI();
                SetCamera = false;
            }
        }


        }



    
}
