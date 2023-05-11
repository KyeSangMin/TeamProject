using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mousecontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;


            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);


            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("RightPoint"))
                {
                    GameObject.Find("SceneManage").GetComponent<SceneManage>().NextSceneLoad(SceneManage.SceneNum);
                }
                if (hit.collider.CompareTag("LeftPoint"))
                {
                    GameObject.Find("SceneManage").GetComponent<SceneManage>().BeforeSceneLoad(SceneManage.SceneNum);
                }
            }


        }


    }



    
}
