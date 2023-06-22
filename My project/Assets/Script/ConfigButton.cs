using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigButton : MonoBehaviour
{


    GameObject Button;
    void Start()
    {
        Button = GameObject.Find("SceneManage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ButtonToMain()
    {
        Button.GetComponent<SceneManage>().ReturnMain();
    }
}
