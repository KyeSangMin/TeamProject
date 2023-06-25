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
        Transform player = GameObject.Find("Player").GetComponent<Transform>();

        isOnUI = true;
        gameObject.transform.localPosition = new Vector3(player.position.x + 1.5f, -1.0f, 1.0f);
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
