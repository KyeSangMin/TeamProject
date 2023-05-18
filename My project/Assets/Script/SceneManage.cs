using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SceneManage : MonoBehaviour
{

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    GameObject startbutton;
    public CanvasGroup FadeCg;
    public float fadeDuration = 1.0f;
    GameObject MainUI;
    public static int SceneNum;

    // Start is called before the first frame update
    void Start()
    {
        //Scene Openscene;
        SceneManager.LoadSceneAsync("OpenScene", LoadSceneMode.Additive);
        startbutton = GameObject.Find("StartButton");
        FadeCg.alpha = 0.0f;
        MainUI = GameObject.Find("MainUI");
        MainUI.SetActive(false);
        SceneNum = 0;

    }

    // Update is called once per frame


    public void StartGame()
    {
        StartCoroutine(Fade(0.0f));
        
        startbutton.SetActive(false);
        //GameObject.Find("Main Camera").SetActive(false);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("LoadScene", LoadSceneMode.Additive));
        //scenesToLoad.Add(SceneManager.LoadSceneAsync("Level0", LoadSceneMode.Additive));
        scenesToLoad.Remove(SceneManager.UnloadSceneAsync("OpenScene"));
       
        // StartCoroutine("LoadingScreen");
        cutSceneLoad();

    }

    public void cutSceneLoad()
    {
        StartCoroutine(CutScene());
        
    }


    public void NextSceneLoad(int i)
    {
        int DNum = i+1;
        StartCoroutine(Fade(0.0f));
        CheckPlayerPos();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Level" + DNum, LoadSceneMode.Additive));
        scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + i));
        SceneNum++;
        HideMoveButton();
       

    }


    public void BeforeSceneLoad(int i)
    {
        int DNum = i - 1;
        int SNum = i;
        StartCoroutine(Fade(0.0f));
        CheckPlayerPos();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Level" + DNum, LoadSceneMode.Additive));
        scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SNum));
        SceneNum--;
        HideMoveButton();
       
    }

    public void TeleportFirst()
    {

       
        if(SceneNum != 0)
        {
            StartCoroutine(Fade(0.0f));
            CheckPlayerPos();
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level0", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            SceneNum = 0;
            HideMoveButton();
        }
        
    }


    public void TelportSecond()
    {
       
        if (SceneNum != 1)
        {
            StartCoroutine(Fade(0.0f));
            CheckPlayerPos();
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            SceneNum = 1;
            HideMoveButton();
        }
    }


    public void HideMoveButton()
    {

        if (SceneNum == 0)
        {
            //GameObject.Find("LeftButton").SetActive(false);
            //GameObject.Find("RightButton").SetActive(false);
            MainUI.transform.Find("LeftButton").gameObject.SetActive(false);
            MainUI.transform.Find("RightButton").gameObject.SetActive(false);
        }

        else
        {
           // GameObject.Find("LeftButton").SetActive(true);
            //GameObject.Find("RightButton").SetActive(true);
            MainUI.transform.Find("LeftButton").gameObject.SetActive(true);
            MainUI.transform.Find("RightButton").gameObject.SetActive(true);
        }
    
    }

    public void CheckPlayerPos()
    {
        // 0 left 1 right
       // new Vector3 pos;
        if(GameObject.Find("Player").GetComponent<PlayerMovement>().State == 0)
        {
            GameObject.Find("Player").transform.position = GameObject.Find("RightCameraPoint").transform.position;
            GameObject.Find("Player").GetComponent<PlayerMovement>().State = 1;
        }
        else
        {
            GameObject.Find("Player").transform.position = GameObject.Find("LeftCameraPoint").transform.position;
            GameObject.Find("Player").GetComponent<PlayerMovement>().State = 0;
        }





    }



    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for(int i = 0; i < scenesToLoad.Count; i++)
        {
            while(!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                yield return null;
            }
        }
    }

    IEnumerator Fade(float finalAlpha)
    {

        FadeCg.alpha = 1.0f;

        FadeCg.blocksRaycasts = true;

        while(!Mathf.Approximately(FadeCg.alpha, finalAlpha))
        {
            FadeCg.alpha = Mathf.MoveTowards(FadeCg.alpha, finalAlpha, fadeDuration * Time.deltaTime);
        

        yield return null;
        }
        FadeCg.blocksRaycasts = false;
    }

    IEnumerator CutScene()
    {


        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fade(0.0f));
        MainUI.SetActive(true);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Level0", LoadSceneMode.Additive));
        scenesToLoad.Remove(SceneManager.UnloadSceneAsync("LoadScene"));
        HideMoveButton();


    }

    
}
