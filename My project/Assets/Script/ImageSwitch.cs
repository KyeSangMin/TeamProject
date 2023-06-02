using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitch : MonoBehaviour
{

    GameObject DataManager;


    public Sprite sprite;
    Image image;



    // Start is called before the first frame update
    void Start()
    {
        DataManager = GameObject.Find("SceneManage");
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void CheckData()
    {
      
            image.sprite = sprite;
        
       
    }


}
