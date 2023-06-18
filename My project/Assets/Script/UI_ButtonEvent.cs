using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ButtonEvent : MonoBehaviour
{

    GameObject Puzzle_UI;
    GameObject PAD_UI;
    GameObject CharInfo;
    GameObject ItemInfo;
    GameObject MapInfo;
    GameObject CharInfo_Inside;
    GameObject sound;
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
        ItemInfo = GameObject.Find("UI_ItemInfo");
        MapInfo = GameObject.Find("UI_Map");
        CharInfo_Inside = GameObject.Find("UI_CharInfoInside");
        CharInfo.SetActive(false);
        ItemInfo.SetActive(false);
        MapInfo.SetActive(false);
        CharInfo_Inside.SetActive(false);


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
        if (PAD_UI.activeSelf == true)
        {
            PAD_UI.SetActive(false);
            CharInfo.SetActive(false);
            ItemInfo.SetActive(false);
            MapInfo.SetActive(false);
            CharInfo_Inside.SetActive(false);
        }
        else
        {
            PAD_UI.SetActive(true);
            CharInfo.SetActive(false);
            ItemInfo.SetActive(false);
            MapInfo.SetActive(false);
            CharInfo_Inside.SetActive(false);

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
    
    public void CharInfoData()
    {
        sound.GetComponent<SoundManager>().PlayEffect(1);
        CharInfo_Inside.SetActive(true);
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
