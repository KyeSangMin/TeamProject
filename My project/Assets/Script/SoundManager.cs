using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public AudioClip TitleClip;
    public AudioClip MainClip;
    public AudioClip ClickClip;
    public AudioClip DoorClip;

    GameObject Bgm;
    GameObject Effect;
    //GameObject SceneManage;

    AudioSource BgmSource;
    AudioSource EffectSource;

    // Start is called before the first frame update
    void Start()
    {
        Bgm = GameObject.Find("BgmSound");
        Effect = GameObject.Find("EffectSound");
        //SceneManage = GameObject.Find("SceneManage");
        BgmSource = Bgm.GetComponent<AudioSource>();
        EffectSource = Effect.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBgm(int SceneType)
    {
        if(SceneType == 0)
        {    
            BgmSource.clip = TitleClip;
            BgmSource.loop = true;
            BgmSource.Play();
        }
        else if(SceneType == 1)
        {
            BgmSource.clip = MainClip;
            BgmSource.loop = true;
            BgmSource.Play();
        }
    }

    public void PlayEffect(int type)
    {

        if (type == 1)
        {
            //EffectSource.clip = ClickClip;
            EffectSource.PlayOneShot(ClickClip);
        }
        else if(type == 2)
        {
            EffectSource.PlayOneShot(DoorClip);
        }

    }
}
