using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ButtonEvent : MonoBehaviour
{

    GameObject Puzzle_UI;
    GameObject PAD_UI;
    GameObject Dialogue_UI;

    // Start is called before the first frame update
    void Start()
    {
        Puzzle_UI = GameObject.Find("UI_Puzzle");
        PAD_UI = GameObject.Find("UI_SlidePad");
        Dialogue_UI = GameObject.Find("UI_Dialogue");
        Puzzle_UI.SetActive(false);
        PAD_UI.SetActive(false);
        Dialogue_UI.SetActive(false);
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
        }
        else
        {
            PAD_UI.SetActive(true);
        }
    }

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







}
