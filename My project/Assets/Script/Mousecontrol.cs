using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mousecontrol : MonoBehaviour
{
    // Start is called before the first frame update



    GameObject sound;
    bool SetCamera;
    //bool ScanActive;

    DialogueEvent dialogueEvent;

    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<CRTEffect>().enabled = false;
        sound = GameObject.Find("AudioManager");
        SetCamera = false;
        //ScanActive = false;

        dialogueEvent = gameObject.GetComponent<DialogueEvent>();
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


            if(hit.collider != null)
            {
                if(SetCamera == true)
                {
                  
                    if(hit.collider.CompareTag("ScanItem"))
                    {
                        sound.GetComponent<SoundManager>().PlayEffect(1);
                        GameObject.Find("Main Camera").GetComponent<FollowCam>().ShakeTime = 0.5f;
                 
                        GameObject.Find("MainUI").GetComponent<NoiseEffect>().StartNose(0.1f);
                        hit.collider.gameObject.GetComponent<ScanItem>().ClickItem();
                        hit.collider.gameObject.SetActive(false);
                        
                    }

                }
                else
                {
                    if (hit.collider.CompareTag("RightPoint"))
                    {
                        sound.GetComponent<SoundManager>().PlayEffect(2);
                        GameObject.Find("SceneManage").GetComponent<SceneManage>().NextSceneLoad(SceneManage.SceneNum);
                    }
                    if (hit.collider.CompareTag("LeftPoint"))
                    {
                        sound.GetComponent<SoundManager>().PlayEffect(2);
                        GameObject.Find("SceneManage").GetComponent<SceneManage>().BeforeSceneLoad(SceneManage.SceneNum);
                    } 
                    if(hit.collider.CompareTag("Item"))
                    {
                        sound.GetComponent<SoundManager>().PlayEffect(1);
                        hit.collider.gameObject.GetComponent<ScanItem>().ClickItem();
                        hit.collider.gameObject.SetActive(false);
                       
                    }
                    if(hit.collider.CompareTag("NPC"))
                    {
                        CharData target = hit.collider.GetComponent<CharData>();

                        sound.GetComponent<SoundManager>().PlayEffect(1);
                        GameObject.Find("SceneManage").GetComponent<DataManager>().AddCharInfo(target.getNumber());

                        /// if(아이템 넘버 data가 존재할 경우)
                        ///     target.CallEvent(아이템 넘버)
                        if (target.CharEvent == 0) target.CallEvent(10);    // 아이템 9번 data 테스트

                        switch (target.CharEvent)
                        {
                            // 0: 인사말, 1: 반복 대사, 2~21: 아이템별 상호작용 대사, 22~24: 확장가능공간(이벤트 추가시 사용)
                            // 250~255: 고정 이벤트 인덱스(연락, 차장실에서 설명충 on, 맞췄을때, 못맞췄을때)
                            case 0:
                                // npc를 클릭하면 npc의 고유번호가 eventManager(= DialogueEvent)로 전달
                                dialogueEvent.EnableEvent(target.getNumber(), target.FirstContect());
                                ChatBubbleManager.isTalking = true;
                                break;

                            case 1:
                            case int n when (n >= 2 && n <= 24):
                                dialogueEvent.EnableEvent(target.getNumber(), target.CharEvent);
                                ChatBubbleManager.isTalking = true;
                                target.EndEvent();
                                break;

                            case int n when (n >= 250 && n <= 255):
                                dialogueEvent.EnableEvent(0, target.CharEvent);
                                ChatBubbleManager.isTalking = true;
                                target.EndEvent();
                                break;

                            default:
                                dialogueEvent.EnableEvent(target.getNumber(), 1);
                                ChatBubbleManager.isTalking = true;
                                break;
                        }
                    }
                    if(hit.collider.CompareTag("ChatBubble"))
                    {
                        ChatBubbleManager.isChat = false;
                        Destroy(GameObject.FindWithTag("ChatBubble"));
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
