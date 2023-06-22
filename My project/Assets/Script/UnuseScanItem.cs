using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnuseScanItem : MonoBehaviour
{

    GameObject Unused;
    // Start is called before the first frame update
    void Start()
    {
        
        Unused = GameObject.Find("ScanInfoUI");
        Unused.SetActive(false);
    }


    public void ActiveItemInfo()
    {
        //Unused.SetActive(true);
    }
}
