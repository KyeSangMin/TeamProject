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
    GameObject sound;
    GameObject configbutton;
    


    // Start is called before the first frame update
    void Start()
    {

        //Scene Openscene;
        sound = GameObject.Find("AudioManager");
        startbutton = GameObject.Find("StartButton");
        configbutton = GameObject.Find("config");
        FadeCg.alpha = 0.0f;
        MainUI = GameObject.Find("MainUI");
        MainUI.SetActive(false);
        SceneNum = 0;
        StartCoroutine(Black());
        


    }

    // Update is called once per frame


    public void StartGame()
    {
        StartCoroutine(Fade(0.0f));
        sound.GetComponent<SoundManager>().PlayBgm(1);

        startbutton.SetActive(false);
        GameObject.Find("config").SetActive(false);
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
        

        if (SceneNum != 0)
        {

            StartCoroutine(Fade(0.0f));
            GameObject.Find("Player").transform.position = GameObject.Find("RightCameraPoint").transform.position;
            GameObject.Find("Player").GetComponent<PlayerMovement>().State = 1;
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


    public void Teleport3()
    {
        if (SceneNum != 2)
        {
            
            StartCoroutine(Fade(0.0f));
            CheckPlayerPos();
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level2", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            SceneNum = 2;
            HideMoveButton();
        }
        
    }

    public void Teleport4()
    {
        if (SceneNum != 3)
        {
           
            StartCoroutine(Fade(0.0f));
            CheckPlayerPos();
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level3", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            SceneNum = 3;
            HideMoveButton();
        }
        
    }

    public void Teleport5()
    {
        if (SceneNum != 4)
        {
            
            StartCoroutine(Fade(0.0f));
            CheckPlayerPos();
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level4", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            SceneNum = 4;
            HideMoveButton();
        }
       
    }

    public void Teleport6()
    {
        if (SceneNum != 5)
        {
            
            StartCoroutine(Fade(0.0f));
            CheckPlayerPos();
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level5", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            SceneNum = 5;
            HideMoveButton();
        }
        
    }


    public void Teleport7()
    {
        if (SceneNum != 6)
        {
          
            StartCoroutine(Fade(0.0f));
            GameObject.Find("Player").transform.position = GameObject.Find("LeftCameraPoint").transform.position;
            GameObject.Find("Player").GetComponent<PlayerMovement>().State = 0;
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level6", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            SceneNum = 6;
            HideMoveButton();
        }
       
    }

    public void TeleportRoom1()
    {
        if(GameObject.Find("Player").GetComponent<PlayerMovement>().State == 0)
        {
            StartCoroutine(Fade(0.0f));
            GameObject.Find("PlayerSprite").transform.position = new Vector3(6.45f, -1.0f);
            scenesToLoad.Add(SceneManager.LoadSceneAsync("PubicRoom1", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            HideMoveButton();
        }
        else if(GameObject.Find("Player").GetComponent<PlayerMovement>().State == 1)
        {
            StartCoroutine(Fade(0.0f));
            GameObject.Find("PlayerSprite").transform.position = new Vector3(6.45f, -1.0f);
            scenesToLoad.Add(SceneManager.LoadSceneAsync("PubicRoom2", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            HideMoveButton();
        }
        else if(GameObject.Find("Player").GetComponent<PlayerMovement>().State == 2)
        {
            StartCoroutine(Fade(0.0f));
            GameObject.Find("PlayerSprite").transform.position = new Vector3(6.45f, -1.0f);
            scenesToLoad.Add(SceneManager.LoadSceneAsync("PubicRoom3", LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
            HideMoveButton();
        }
       
    }
    public void TeleportRoom2()
    {
        StartCoroutine(Fade(0.0f));
        GameObject.Find("PlayerSprite").transform.position = new Vector3(6.45f, -1.0f);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("PubicRoom2", LoadSceneMode.Additive));
        scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
        HideMoveButton();
    }
    public void TeleportRoom3()
    {
        StartCoroutine(Fade(0.0f));
        GameObject.Find("PlayerSprite").transform.position = new Vector3(6.45f, -1.0f);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("PubicRoom3", LoadSceneMode.Additive));
        scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Level" + SceneNum));
        HideMoveButton();
    }
    public void TeleportRetrun()
    {
        
        StartCoroutine(Fade(0.0f));
        if(GameObject.Find("Player").GetComponent<PlayerMovement>().State == 0)
        {
            GameObject.Find("Player").transform.position = GameObject.Find("LeftCameraPoint").transform.position;
            GameObject.Find("PlayerSprite").transform.position = new Vector3(6.45f, -2.0f);
            GameObject.Find("Player").GetComponent<PlayerMovement>().State = 0;
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level" + SceneNum, LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("PubicRoom1"));
        }
        else if (GameObject.Find("Player").GetComponent<PlayerMovement>().State == 1)
        {
            GameObject.Find("Player").transform.position = GameObject.Find("RightCameraPoint").transform.position;
            GameObject.Find("PlayerSprite").transform.position = new Vector3(6.45f, -2.0f);
            GameObject.Find("Player").GetComponent<PlayerMovement>().State = 0;
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level" + SceneNum, LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("PubicRoom2"));
        }
        else if(GameObject.Find("Player").GetComponent<PlayerMovement>().State == 2)
        {
            GameObject.Find("Player").transform.position = GameObject.Find("Level3RightPoint").transform.position;
            GameObject.Find("PlayerSprite").transform.position = new Vector3(6.45f, -2.0f);
            GameObject.Find("Player").GetComponent<PlayerMovement>().State = 0;
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level" + SceneNum, LoadSceneMode.Additive));
            scenesToLoad.Remove(SceneManager.UnloadSceneAsync("PubicRoom3"));
        }
        //GameObject.Find("Player").transform.position = GameObject.Find("LeftCameraPoint").transform.position;
       
    }

    public void LoadConfig()
    {
        StartCoroutine(Fade(0.0f));
        //sound.GetComponent<SoundManager>().PlayBgm(1);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Config", LoadSceneMode.Additive));
        scenesToLoad.Remove(SceneManager.UnloadSceneAsync("OpenScene"));
        GameObject.Find("StartButton").SetActive(false) ;
        GameObject.Find("config").SetActive(false);


        //SceneManager.LoadScene("Config");


    }

    public void ReturnMain()
    {
        
        StartCoroutine(Fade(0.0f));
        //GameObject.Find("MainCanvas").SetActive(true);
        //sound.GetComponent<SoundManager>().PlayBgm(1);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("OpenScene", LoadSceneMode.Additive));
        scenesToLoad.Remove(SceneManager.UnloadSceneAsync("Config"));
        startbutton.SetActive(true);
        configbutton.SetActive(true);


    }





    public void HideMoveButton()
    {

        if (SceneNum == 0 || SceneNum ==6)
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

    public int getSceneNum()
    {
        return SceneNum;
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

    IEnumerator Black()
    {
        
        yield return new WaitForSeconds(0.75f);
        GameObject.Find("BlackImage").SetActive(false);
        SceneManager.LoadSceneAsync("OpenScene", LoadSceneMode.Additive);
        sound.GetComponent<SoundManager>().PlayBgm(0);
    }

}
