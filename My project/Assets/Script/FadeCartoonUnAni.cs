using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCartoonUnAni : MonoBehaviour
{

    public CanvasGroup FadeCg;
    //public Color Fadevelued;
    //public GameObject FadeImage;
    //public float Fadevalue;
    public float fadeDuration = 1.0f;
    public bool FinshCartoon;

    // Start is called before the first frame update
    void Start()
    {
        FadeCg.alpha = 0.0f;
        FinshCartoon = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadedImage()
    {
        StartCoroutine(Fadecartoon(1.0f));
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
        FinshCartoon = true;
        GameObject.Find("CartoonCanvas").GetComponent<CartoonControl>().CartControl();


    }
}
