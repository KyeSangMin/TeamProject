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
                        sound.GetComponent<SoundManager>().PlayEffect(1);
                        GameObject.Find("SceneManage").GetComponent<DataManager>().AddCharInfo(hit.collider.GetComponent<CharData>().getNumber());

                        dialogueEvent.EnableEvent(hit.collider.GetComponent<CharData>().getNumber());
                        ChatBubbleManager.isTalking = true;
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
