using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ButtonEvent : MonoBehaviour
{

    GameObject Puzzle_UI;
    GameObject PAD_UI;
    GameObject CharInfo;
    GameObject EndChar;
    GameObject ItemInfo;
    GameObject MapInfo;
    GameObject CharInfo_Inside;

    public GameObject UISettings;
    GameObject sound;
    public bool UiSetUp;
    //GameObject Dialogue_UI;

    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.Find("AudioManager");
        //Puzzle_UI = GameObject.Find("UI_Puzzle");
        PAD_UI = GameObject.Find("UI_SlidePad");
       // Dialogue_UI = GameObject.Find("UI_Dialogue");
       // Puzzle_UI.SetActive(false);
        PAD_UI.SetActive(false);
   
        //Dialogue_UI.SetActive(false);

        CharInfo = GameObject.Find("UI_CharInfo");
        EndChar = GameObject.Find("UI_EndChar");
        ItemInfo = GameObject.Find("UI_ItemInfo");
        MapInfo = GameObject.Find("UI_Map");
        CharInfo_Inside = GameObject.Find("UI_CharInfoInside");
        UISettings = GameObject.Find("UI_Setting");
        CharInfo.SetActive(false);
        EndChar.SetActive(false);
        ItemInfo.SetActive(false);
        MapInfo.SetActive(false);
        CharInfo_Inside.SetActive(false);
        UISettings.SetActive(false);
        UiSetUp = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SetPuzzleActive()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);

        if (Puzzle_UI.activeSelf == true)
        {
            Puzzle_UI.SetActive(false);
        }
        else
        {
            Puzzle_UI.SetActive(true);
        }


    }


    public void SetPadActive()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().DestroyPuzzle();

        if (GameObject.Find("SceneManage").GetComponent<DataManager>().EndEvent == 21)
        {
            EndChar.SetActive(true);
        }
        else
        {
            if (PAD_UI.activeSelf == true)
            {
                PAD_UI.SetActive(false);
                CharInfo.SetActive(false);
                ItemInfo.SetActive(false);
                MapInfo.SetActive(false);
                CharInfo_Inside.SetActive(false);
                UiSetUp = false;
            }
            else
            {
                PAD_UI.SetActive(true);
                CharInfo.SetActive(false);
                ItemInfo.SetActive(false);
                MapInfo.SetActive(false);
                CharInfo_Inside.SetActive(false);
                UiSetUp = true;

            }
        }
       
    }


    public void SetPadButton_1()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        if (CharInfo.activeSelf == true)
        {
            CharInfo.SetActive(false);
            PAD_UI.SetActive(true);
            
        }
        else
        {
            CharInfo.SetActive(true);
            PAD_UI.SetActive(false);
            GameObject.Find("SceneManage").GetComponent<DataManager>().CheckCharInfo();
        }

    }

    public void SetPadButton_2()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        if (ItemInfo.activeSelf == true)
        {
            ItemInfo.SetActive(false);
            PAD_UI.SetActive(true);
            
        }
        else
        {
            ItemInfo.SetActive(true);
            PAD_UI.SetActive(false);
            GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 1;
            GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
            GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemSprtite();
        }
    }

    public void SetPadButton_3()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        if (MapInfo.activeSelf == false)
        {
            MapInfo.SetActive(true);
            PAD_UI.SetActive(false);
        }
        else
        {
            MapInfo.SetActive(false);
            PAD_UI.SetActive(true);
        }
    }
    

    public void SetPadsetting()
    {
        if(UISettings.activeSelf == true)
        {
            UISettings.SetActive(false);
        }
        else
        {
            UISettings.SetActive(true);
        }
       
    }
    public void ResetPadButton()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        PAD_UI.SetActive(true);
        CharInfo.SetActive(false);
        ItemInfo.SetActive(false);
        MapInfo.SetActive(false);
        CharInfo_Inside.SetActive(false);
    }
    public void ResetCharInfoButton()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(false);
        CharInfo.SetActive(true);
     }

    /*
    public void CharInfoData()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(1);
        CharInfo.SetActive(false);

    }
    */
    public void CharInfoButton1()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(0);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton2()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(1);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton3()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(2);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton4()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(3);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton5()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(4);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton6()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(5);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton7()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(6);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton8()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(7);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton9()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(8);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton10()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(9);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton11()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(10);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton12()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(11);
        CharInfo.SetActive(false);

    }

    public void CharInfoButton13()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadCharInfo(12);
        CharInfo.SetActive(false);

    }




    public void ItemButton1()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 1;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton2()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 2;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton3()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 3;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton4()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 4;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton5()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 5;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton6()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 6;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton7()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 7;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton8()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 8;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton9()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 9;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton10()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 10;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton11()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 11;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton12()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 12;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton13()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 13;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton14()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 14;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton15()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 15;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton16()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 16;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton17()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 17;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton18()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 18;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton19()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 19;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void ItemButton20()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList = 20;
        GameObject.Find("SceneManage").GetComponent<DataManager>().LoadItemInfo();
    }

    public void GetItemInfo()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        int i = GameObject.Find("SceneManage").GetComponent<DataManager>().ItemList;
        if (GameObject.Find("SceneManage").GetComponent<DataManager>().CheckItem(i))
        {
            GameObject.Find("SceneManage").GetComponent<Mousecontrol>().GetItem = true;
            GameObject.Find("Button").GetComponent<ImageSwitch>().sprite = GameObject.Find("ItemImage_" + i).GetComponent<ImageSwitch>().sprite;
            GameObject.Find("Button").GetComponent<ImageSwitch>().SwitchItemImage();
            Debug.Log("GetItem");

        }

    }
    public void EndingTrue()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<SceneManage>().FadeEffect();
        GameObject.Find("SceneManage").GetComponent<SceneManage>().TeleportEnd(0);


    }


    public void EndingFalse()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        GameObject.Find("SceneManage").GetComponent<SceneManage>().FadeEffect();
        GameObject.Find("SceneManage").GetComponent<SceneManage>().TeleportEnd(1);

    }
   
    public void CheatEvent()
    {
        GameObject.Find("SceneManage").GetComponent<DataManager>().EndEvent = 20;
    }

    /*
    public void SetDialogueActive()
    {

        if (Dialogue_UI.activeSelf == true)
        {
            Dialogue_UI.SetActive(false);
        }
        else
        {
            Dialogue_UI.SetActive(true);
        }


    }

    */





}
