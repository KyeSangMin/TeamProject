using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnuseScanItem : MonoBehaviour
{
    GameObject Unused;
    bool isOnUI;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        isOnUI = false;
        Unused = GameObject.Find("ScanInfoUI");
        Unused.SetActive(isOnUI);
    }


    public void ActiveItemInfo()
    {
        isOnUI = true;
        StartCoroutine(UnusedUIActivation());
    }

    public void offUnsedUI()
    {
        isOnUI = false;
        Unused.SetActive(isOnUI);
    }

    IEnumerator UnusedUIActivation()
    {
        Unused.SetActive(isOnUI);
        yield return new WaitForSeconds(waitTime);
        if(isOnUI)
        {
            isOnUI = false;
            GameObject.Find("MainUI").GetComponent<NoiseEffect>().StartNose(0.1f);
            Unused.SetActive(isOnUI);
        }
    }
}
