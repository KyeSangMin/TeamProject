using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DataManager : MonoBehaviour
{

    //public List<bool> CharInfos = new List<bool>();
    [SerializeField]
    public ArrayList CharArray = new ArrayList();
    public GameObject Char1;
    GameObject CharUI;

    public bool Item1;
    public bool Item2;
    public bool Item3;
    public bool Item4;
    public bool Item5;
    public bool Item6;
    public bool Item7;
    public bool Item8;
    public bool Item9;
    public bool Item10;
    public bool Item11;
    public bool Item12;
    public bool Item13;
    public bool Item14;
    public bool Item15;
    public bool Item16;
    public bool Item17;
    public bool Item18;
    public bool Item19;
    public bool Item20;
    public int ItemList;

    public string defultTitletext;
    public string defultMaintext;


    public GameObject Puzzle1;
    public GameObject Puzzle2;
    public GameObject Puzzle3;

    public bool Door0to1;
    public bool Door2to3;
    public bool Door5to6;
    public GameObject instpuzzle;
    public GameObject instpuzzle2;
    public GameObject instpuzzle3;
    DialogueEvent dialogueEvent;
    public int EndEvent;
    public List<int> CheckedList;


    // Start is called before the first frame update
    void Start()
    {


        CharUI = GameObject.Find("MainUI");
        for (int i = 0; i < 13; i++)
        {
            //CharInfos.Add(false);
            CharArray.Add(false);
        }
        CharArray[0] = true;
        CharArray[6] = true;
        CharArray[12] = true;

        Item1 = false;
        Item2 = false;
        Item3 = false;
        Item4 = false;
        Item5 = false;
        Item6 = false;
        Item7 = false;
        Item8 = false;
        Item9 = false;
        Item10 = false;
        Item11 = false;
        Item12 = false;
        Item13 = false;
        Item14 = false;
        Item15 = false;
        Item16 = false;
        Item17 = false;
        Item18 = false;
        Item19 = false;
        Item20 = false;
        ItemList = 1;

        Door0to1 = false;
        Door2to3 = false;
        Door5to6 = false;

     

        defultTitletext = "????";
        defultMaintext = "?????????";

        EndEvent = 0;
        dialogueEvent = gameObject.GetComponent<DialogueEvent>();
        

    }



    // Update is called once per frame
    void Update()
    {
       
    }

    public void EndingEvent()
    {
        if (EndEvent == 20)
        {

            dialogueEvent.EnableEvent(0, 2);
            ChatBubbleManager.isTalking = true;
            EndEvent++;
            Debug.Log("End");
        }
        else if (EndEvent == 21)
        { 

            dialogueEvent.EnableEvent(0, 3);
            ChatBubbleManager.isTalking = true;
            EndEvent++;
            Debug.Log("Endaaa");
        }
     }

    public void AddCharInfo(int CharNum)
    {

        if(CharNum < 6)
        {
            CharArray[CharNum] = true;
        }
        else
        {
            int i = CharNum + 1;
            CharArray[i] = true;
        }


    }

    public void ListCheck(int i)
    {
        if(!CheckedList.Contains(i))
        {
            CheckedList.Add(i);
            EndEvent++;
            Debug.Log(EndEvent);
        }

    }

    public void CheckCharInfo()
    {

        for (int i = 0; i < 13; i++)
        {
            if(CharArray[i].Equals(true))
            {
                int z = i + 1;
                GameObject.Find("CharImage_"+z).GetComponent<ImageSwitch>().SwichImage();
                GameObject.Find("CharName_" + z).GetComponent<SwitchName>().Switchname();
                //GameObject.Find("CharName_" + z).GetComponent<TextMeshProUGUI>().text = GameObject.Find("CharName_" + z).GetComponent<SwitchName>().Charname.ToString();

            }
            
        }

    }


    public void LoadCharInfo(int type)
    {
        Debug.Log(type);
        if (CharArray[type].Equals(true))
        {
            int i = type+1;
            GameObject.Find("CharTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("CharImage_" + i).GetComponent<ImageSwitch>().TitleText.ToString();
            GameObject.Find("CharTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("CharImage_" + i).GetComponent<ImageSwitch>().MainText.ToString();
            GameObject.Find("CharImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("CharImage_" + i).GetComponent<ImageSwitch>().StandSprite;
            GameObject.Find("CharImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
            Debug.Log("2CharImage_" + i);
           
        }
        else if(CharArray[type].Equals(false))
        {
            int j = type+1;
            GameObject.Find("CharTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
            GameObject.Find("CharTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
            GameObject.Find("CharImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("CharImage_" + j).GetComponent<ImageSwitch>().silhouetteStandSprite;
            GameObject.Find("CharImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
            Debug.Log("CharImage_" + j);
            Debug.Log("charfalse");
        }
    }

    public void CheckDoor()
    {
        if (instpuzzle|| instpuzzle2|| instpuzzle3)
        {
            return;
        }
        else
        {
      
            switch (GameObject.Find("SceneManage").GetComponent<SceneManage>().getSceneNum())
            {

                case 0:
                    if(Door0to1)
                    {
                        GameObject.Find("SceneManage").GetComponent<SceneManage>().NextSceneLoad(SceneManage.SceneNum);
                        Debug.Log("1");
                        return;
                  
                    }
                    else
                    {

                        instpuzzle = Instantiate(Puzzle1);
                        instpuzzle.SetActive(true);
                        //Puzzle1.SetActive(true);
                        Debug.Log("2");
                    
                    }
                    break;

                case 2:
                    if(Door2to3)
                    {
                        GameObject.Find("SceneManage").GetComponent<SceneManage>().NextSceneLoad(SceneManage.SceneNum);
                        return;
                    }
                    else
                    {
                        instpuzzle2 = Instantiate(Puzzle2);
                        instpuzzle2.SetActive(true);
                    }
                    break;

                case 5:
                    if(Door5to6)
                    {
                        GameObject.Find("SceneManage").GetComponent<SceneManage>().NextSceneLoad(SceneManage.SceneNum);
                        return;
                    }
                    else
                    {
                        instpuzzle3 = Instantiate(Puzzle3);
                        instpuzzle3.SetActive(true);
                    }
                    break;

                default:
                    GameObject.Find("SceneManage").GetComponent<SceneManage>().NextSceneLoad(SceneManage.SceneNum);
                    break;


            }
        }
    }

    public void DestroyPuzzle()
    {

            Destroy(instpuzzle);


            Destroy(instpuzzle2);


            Destroy(instpuzzle3);

    }

    public void LoadItemInfo()
    {
      
        switch (ItemList)
        {
            case 1:
                if(Item1)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_1").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_1").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_1").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_1").GetComponent<ImageSwitch>().MainText.ToString();
                }
               else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_1").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_1").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();            
                }
                break;

            case 2:
                if (Item2)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_2").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_2").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_2").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_2").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_2").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_2").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;

            case 3:
                if (Item3)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_3").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_3").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_3").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_3").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_3").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_3").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;

            case 4:
                if (Item4)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_4").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_4").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_4").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_4").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_4").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_4").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 5:
                if (Item5)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_5").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_5").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_5").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_5").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_5").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_5").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 6:
                if (Item6)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_6").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_6").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_6").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_6").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_6").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_6").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 7:
                if (Item7)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_7").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_7").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_7").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_7").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_7").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_7").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 8:
                if (Item8)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_8").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_8").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_8").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_8").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_8").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_8").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 9:
                if (Item9)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_9").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_9").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_9").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_9").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_9").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_9").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 10:
                if (Item10)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_10").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_10").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_10").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_10").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_10").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_10").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 11:
                if (Item11)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_11").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_11").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_11").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_11").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_11").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_11").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 12:
                if (Item12)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_12").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_12").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_12").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_12").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_12").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_12").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 13:
                if (Item13)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_13").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_13").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_13").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_13").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_13").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_13").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 14:
                if (Item14)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_14").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_14").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_14").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_14").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_14").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_14").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 15:
                if (Item15)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_15").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_15").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_15").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_15").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_15").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_15").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 16:
                if (Item16)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_16").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_16").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_16").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_16").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_16").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_16").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 17:
                if (Item17)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_17").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_17").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_17").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_17").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_17").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_17").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 18:
                if (Item18)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_18").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_18").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_18").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_18").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_18").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_18").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 19:
                if (Item19)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_19").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_19").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_19").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_19").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_19").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_19").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;
            case 20:
                if (Item20)
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_20").GetComponent<ImageSwitch>().sprite;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemImage_20").GetComponent<ImageSwitch>().SwitchItemImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_20").GetComponent<ImageSwitch>().TitleText.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ItemImage_20").GetComponent<ImageSwitch>().MainText.ToString();
                }
                else
                {
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().silhouette = GameObject.Find("ItemImage_20").GetComponent<ImageSwitch>().silhouette;
                    GameObject.Find("ItemImage_big").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemImage_20").GetComponent<ImageSwitch>().SilhouetteImage();
                    GameObject.Find("ItemTextTitle").GetComponent<TextMeshProUGUI>().text = defultTitletext.ToString();
                    GameObject.Find("ItemTextMain").GetComponent<TextMeshProUGUI>().text = defultMaintext.ToString();
                }
                break;

            default:
                break;
        }
    }


    public bool CheckItem(int ItemNum)
    {
        

        return false;
    }

}
