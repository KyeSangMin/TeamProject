using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Cam;
    public GameObject Pos_Left;
    public GameObject Pos_Right;
    public GameObject Level3_right;
    public int State;  // 0 left 1 right
    public Vector3 TargetPos;

    public Animator animator;

    public float smoothTime;

    public bool ButtonState;

    bool pressleft;
    bool pressright;

    void Start()
    {
        State = 1;
        ButtonState = false;
        pressleft = false;
        pressright = false;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckCamPos();

        if(ButtonState && GameObject.Find("SceneManage").GetComponent<SceneManage>().getSceneNum() != 3)
        {
            smoothTime = 1.5f;
            Debug.Log("stage!3");

            // Cam.transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime);
            Cam.transform.position = Vector3.MoveTowards(transform.position, TargetPos,Time.deltaTime *3.0f);
            if (Vector3.Distance(TargetPos, Cam.transform.position) < 0.1f)
            {
                ButtonState = false;
                animator.SetBool("WalkFront", false);
                animator.SetBool("WalkBack", false);
                GameObject.Find("Main Camera").GetComponent<FollowCam>().ShackCheck = true;
                if (this.State == 1)
                {
                    State = 0;
                }
                else
                {
                    State = 1;
                }
            }
        }
        else if(ButtonState && GameObject.Find("SceneManage").GetComponent<SceneManage>().getSceneNum() == 3)
        {
            smoothTime = 1.5f;
            Debug.Log("stage3");

            // Cam.transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime);
            Cam.transform.position = Vector3.MoveTowards(transform.position, TargetPos, 0.01f);
            if (Vector3.Distance(TargetPos, Cam.transform.position) < 0.1f)
            {
                ButtonState = false;
                animator.SetBool("WalkFront", false);
                animator.SetBool("WalkBack", false);

                if (this.State == 0)
                {
                    State = 1;
                }
                else if(this.State == 2)
                {
                    State = 1;
                }
                else if(this.State == 1 && pressleft)
                {
                    State = 0;
                    pressleft = false;
                }
                else if (this.State == 1 && pressright)
                {
                    State = 2;
                    pressright = false;
                }
            }
        }



    }

    void CheckCamPos()
    {

        if(this.State == 1) // 오른쪽에 있음 왼쪽 가르킴
        {
            if(pressright)
            {
                TargetPos = Level3_right.transform.position;
            }
            else if(pressleft)
            {
                TargetPos = Pos_Left.transform.position;
            }
            else
            {
                TargetPos = Pos_Left.transform.position;
            }
            
        }
        else if(this.State == 0) // 왼쪽에 있음 오른쪽 가르킴
        {
            TargetPos = Pos_Right.transform.position;
        }

        else if(this.State == 2) // level3일떄 가장 오른쪽에 있음 가운데 즉 state1을 가르킴 
        {
            TargetPos = Pos_Right.transform.position;
        }

    }

    public void OnEventLeftButton()  // 오른쪽
    {
        GameObject.Find("Main Camera").GetComponent<FollowCam>().ShackCheck = false; 

        if(GameObject.Find("SceneManage").GetComponent<SceneManage>().getSceneNum() !=3)
        {
            if (State == 0)
            {
                animator.SetBool("WalkFront", true);
                ButtonState = true;
                
            }

        }

        else
        {
            if (State == 0)
            {
                animator.SetBool("WalkFront", true);
                ButtonState = true;
                pressright = true;
               
            }
            else if (State == 1)
            {
                animator.SetBool("WalkFront", true);
                ButtonState = true;
                pressright = true;
               
            }

        }


      

        
    }
    public void OnEventRightButton()
    {
        GameObject.Find("Main Camera").GetComponent<FollowCam>().ShackCheck = false;
        if (GameObject.Find("SceneManage").GetComponent<SceneManage>().getSceneNum() != 3)
        {
            if (State == 1)
            {
                ButtonState = true;
                animator.SetBool("WalkBack", true);
            }
        }

        else
        {
            if (State == 1)
            {
                ButtonState = true;
                pressleft = true;
                animator.SetBool("WalkBack", true);
            }
            else if (State == 2)
            {
                ButtonState = true;
                pressleft = true;
                animator.SetBool("WalkBack", true);
            }

        }

    }


}
