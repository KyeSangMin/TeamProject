using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    //public List<bool> CharInfos = new List<bool>();
    public ArrayList CharArray = new ArrayList();
    public GameObject Char1;
    GameObject CharUI;
    // Start is called before the first frame update
    void Start()
    {


        CharUI = GameObject.Find("MainUI");
        for (int i = 1; i < 14; i++)
        {
            //CharInfos.Add(false);
            CharArray.Add(false);
        }
        

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCharInfo(int CharNum)
    {

        CharArray[CharNum] = true;

        Debug.Log(CharArray[CharNum]);


    }


    public void CheckCharInfo()
    {

        for (int i = 0; i < 13; i++)
        {
            if(CharArray[i].Equals(true))
            {
                GameObject.Find("CharImage_"+i).GetComponent<ImageSwitch>().SwichImage();
            }
            
        }

    }


}
