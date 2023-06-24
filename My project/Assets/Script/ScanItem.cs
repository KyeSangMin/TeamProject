using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScanItem : MonoBehaviour
{

    public int ItemIndex;
   
    // Start is called before the first frame update
    void Start()
    {
        switch(ItemIndex)
        {
            case 1:
                if(GameObject.Find("SceneManage").GetComponent<DataManager>().Item1 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 2:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item2 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 3:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item3 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 4:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item4 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 5:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item5 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 6:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item6 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 7:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item7 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 8:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item8 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 9:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item9 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 10:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item10 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 11:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item11 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 12:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item12 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 13:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item13 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 14:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item14 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 15:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item15 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 16:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item16 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 17:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item17 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 18:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item18 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 19:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item19 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 20:
                if (GameObject.Find("SceneManage").GetComponent<DataManager>().Item20 == true)
                {
                    this.gameObject.SetActive(false);
                }
                break;


            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ClickItem()
    {
        if(ItemIndex == 1)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item1 = true;
        }
       else if(ItemIndex == 2)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item2 = true;
        }
        else if (ItemIndex == 3)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item3 = true;
        }
        else if (ItemIndex == 4)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item4 = true;
        }
        else if (ItemIndex == 5)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item5 = true;
        }
         else if(ItemIndex == 6)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item6 = true;
        }

        else if (ItemIndex == 7)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item7 = true;
        }

        else if (ItemIndex == 8)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item8 = true;
        }

        else if (ItemIndex == 9)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item9 = true;
        }

        else if (ItemIndex == 10)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item10 = true;
        }

        else if (ItemIndex == 11)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item11 = true;
        }

        else if (ItemIndex == 12)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item12 = true;
        }

        else if (ItemIndex == 13)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item13 = true;
        }

        else if (ItemIndex == 14)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item14 = true;
        }

        else if (ItemIndex == 15)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item15 = true;
        }

        else if (ItemIndex == 16)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item16 = true;
        }

        else if (ItemIndex == 17)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item17 = true;
        }

        else if (ItemIndex == 18)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item18 = true;
        }

        else if (ItemIndex == 19)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item19 = true;
        }

        else if (ItemIndex == 20)
        {
            GameObject.Find("SceneManage").GetComponent<DataManager>().Item20 = true;
        }




    }



}
