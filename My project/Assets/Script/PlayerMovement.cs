using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Cam;
    public GameObject Pos_Left;
    public GameObject Pos_Right;
    public int State;  // 0 left 1 right
    public Vector3 TargetPos;

    public float smoothTime;

    public bool ButtonState;


    void Start()
    {
        State = 1;
        ButtonState = false;

    }

    // Update is called once per frame
    void Update()
    {

        CheckCamPos();

       

        if(ButtonState)
        {
            smoothTime = 1.5f;


            Cam.transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime);

            if(Vector3.Distance(TargetPos, Cam.transform.position) < 0.1f)
            {
                ButtonState = false;
                
                if(this.State == 1)
                {
                    State = 0;
                }
                else
                {
                    State = 1;
                }
            }


        }



    }

    void CheckCamPos()
    {

        if(this.State == 1)
        {
            TargetPos = Pos_Left.transform.position;
        }
        else if(this.State == 0)
        {
            TargetPos = Pos_Right.transform.position;
        }

    }

    public void OnEventLeftButton()
    {

        if(State == 0)
        {
            ButtonState = true;
        }

        
    }
    public void OnEventRightButton()
    {

        if(State == 1)
        {
            ButtonState = true;
        }
        
    }


}
