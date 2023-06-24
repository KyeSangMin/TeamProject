using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartoonControl : MonoBehaviour
{

    public GameObject Cut1;
    public GameObject Cut2;
    public GameObject Cut3;
    public GameObject Cut4;

    // Start is called before the first frame update
    void Start()
    {
        Cut1.GetComponent<FadeCartoonUnAni>().FadedImage();
        GameObject.Find("SceneManage").GetComponent<DataManager>().EndEvent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CartControl()
    {
        if(Cut1.GetComponent<FadeCartoonUnAni>().FinshCartoon && !Cut2.GetComponent<FadeCartoonUnAni>().FinshCartoon)
        {
            Cut2.GetComponent<FadeCartoonUnAni>().FadedImage();
        }
        else if(Cut2.GetComponent<FadeCartoonUnAni>().FinshCartoon && !Cut3.GetComponent<FadeCartoon>().FinshCartoon)
        {
            Cut3.GetComponent<FadeCartoon>().FadedImage();
        }
        else if (Cut3.GetComponent<FadeCartoon>().FinshCartoon && !Cut4.GetComponent<FadeCartoon>().FinshCartoon)
        {
            Cut4.GetComponent<FadeCartoon>().FadedImage();
        }
    }
}
