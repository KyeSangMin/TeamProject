using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitch : MonoBehaviour
{

    //GameObject DataManager;


  
    public Sprite sprite;


    // Start is called before the first frame update
    void Start()
    {
        //DataManager = GameObject.Find("SceneManage");
        
    }

    // Update is called once per frame

    public void SwichImage()
    {
        gameObject.GetComponent<Image>().sprite = sprite;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(18.32664f,120);
    }




}
