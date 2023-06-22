using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SwitchName : MonoBehaviour
{

    public string Charname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switchname()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = Charname.ToString();
    }
}
