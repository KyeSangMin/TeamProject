using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCartoon : MonoBehaviour
{

    public CanvasGroup FadeCg;
    //public Color Fadevelued;
    //public GameObject FadeImage;
    //public float Fadevalue;
    public float fadeDuration = 1.0f;
    public bool FinshCartoon;
    public Animator ani;
    public Image image;
    public Sprite sprite;
    //bool aa;

    // Start is called before the first frame update
    void Start()
    {
        FadeCg.alpha = 0.0f;
        FinshCartoon = false;
        ani = gameObject.GetComponent<Animator>();
        ani.SetBool("SetCartoonStart",false);
        //Fadevalue = 0.0f;
        //Fadevelued = FadeImage.GetComponent<SpriteRenderer>().color;
        //Fadevelued = new Color(1.0f, 1.0f, 1.0f, Fadevalue);
        //StartCoroutine(Fadecartoon(1.0f));
        //FadeImage.  

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadedImage()
    {
        StartCoroutine(Fadecartoon(1.0f));
    }

    public void ChangeImage()
    {
        GameObject.Find("Cartoon_3UI").GetComponent<Animator>().SetBool("SetClear",true);
        Debug.Log("cut4Á¾·á");
    }

    IEnumerator Fadecartoon(float finalAlpha)
    {
   
        FadeCg.alpha = 0.0f;

        FadeCg.blocksRaycasts = true;

        while (!Mathf.Approximately(FadeCg.alpha, finalAlpha))
        {
            FadeCg.alpha = Mathf.MoveTowards(FadeCg.alpha, finalAlpha, fadeDuration * Time.deltaTime);


            yield return null;
        }
        FadeCg.blocksRaycasts = false;
        ani.SetBool("SetCartoonStart", true);
        FinshCartoon = true;
        GameObject.Find("CartoonCanvas").GetComponent<CartoonControl>().CartControl();

             /*
        //Fadevelued = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Fadevalue = 1.0f;
        while (!Mathf.Approximately(Fadevalue, finalAlpha))
        {
            //FadeCg.alpha = Mathf.MoveTowards(FadeCg.alpha, finalAlpha, fadeDuration * Time.deltaTime);
            Fadevalue = Mathf.MoveTowards(Fadevelued.a, finalAlpha, fadeDuration * Time.deltaTime);
            //Fadevelued = new Color(1.0f, 1.0f, 1.0f, Fadevalue);
            yield return null;
        }
             */
    }
}
