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
    //GameObject Dialogue_UI;

    // Start is called before the first frame update
    void Start()
    {
        Puzzle_UI = GameObject.Find("UI_Puzzle");
        PAD_UI = GameObject.Find("UI_SlidePad");
       // Dialogue_UI = GameObject.Find("UI_Dialogue");
        Puzzle_UI.SetActive(false);
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
        if(Puzzle_UI.activeSelf == true)
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
           
        }
    }


    public void SetPadButton_1()
    {
        if(CharInfo.activeSelf == true)
        {
            CharInfo.SetActive(false);
        }
        else
        {
            CharInfo.SetActive(true);
        }

    }

    public void SetPadButton_2()
    {
        if (ItemInfo.activeSelf == true)
        {
            ItemInfo.SetActive(false);
        }
        else
        {
            ItemInfo.SetActive(true);
        }
    }

    public void SetPadButton_3()
    {
        if (MapInfo.activeSelf == false)
        {
            MapInfo.SetActive(true);
        }
        else
        {
            MapInfo.SetActive(false);
        }
    }
    
    public void ResetPadButton()
    {
        PAD_UI.SetActive(true);
        CharInfo.SetActive(false);
        ItemInfo.SetActive(false);
        MapInfo.SetActive(false);
        CharInfo_Inside.SetActive(false);
    }
    public void ResetCharInfoButton()
    {
        CharInfo_Inside.SetActive(false);
        CharInfo.SetActive(true);
     }
    
    public void CharInfoData()
    {
        CharInfo_Inside.SetActive(true);
        CharInfo.SetActive(false);
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
