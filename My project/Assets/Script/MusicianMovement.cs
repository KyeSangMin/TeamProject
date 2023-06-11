using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicianMovement : MonoBehaviour
{

    public GameObject Pos_1;
    public GameObject Pos_2;
    public GameObject Pos_3;
    public GameObject Pos_4;
    public GameObject Pos_5;
    public Vector3 TargetPos;

    public GameObject[] Poses;

    public bool CheckMove;
    public bool CheckRandPos;

    public Animator animator;
    public float NPCDelayTime;
    public enum NPCStates
    {
        Idle,
        Move,
        Something
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        TargetPos = Poses[4].transform.position;
        CheckMove = true;
        animator.SetBool("leftSide", false);
        animator.SetBool("RightSide", true);
        animator.SetBool("isWalk", false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (CheckMove)
        {
            if(CheckRandPos)
            {
                RandPos();
               
            }
            
            NPCMove();
        }
        
    }



    

    void NPCMove()
    {
        animator.SetBool("isWalk", true);
        //TargetPos = Pos_2.transform.position;
        this.transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * 3.0f);
        if (Vector3.Distance(TargetPos, this.transform.position) < 0.1f)
        {
            CheckMove = false;
            CheckRandPos = true;
            animator.SetBool("isWalk", false);
            StartCoroutine(NPCDelay(NPCDelayTime));
        }
        
     
    }


    void RandPos()
    {
        int rand = Random.Range(0, 4);
        TargetPos = Poses[rand].transform.position;
       
        if (TargetPos.x == this.transform.position.x)
        {
            RandPos();
        }
        CheckRandPos = false;
        Checkdirection();
    }

    void Checkdirection()
    {
        if(TargetPos.x > this.transform.position.x)
        {
            animator.SetBool("leftSide", false);
            animator.SetBool("RightSide", true);
        }
        else if(TargetPos.x < this.transform.position.x)
        {
            animator.SetBool("leftSide", true);
            animator.SetBool("RightSide", false);
        }
        else if(TargetPos.x < this.transform.position.x)
        {
            RandPos();
        }
    }

    void NPCIdle()
    {

    }

    IEnumerator NPCDelay(float NPCDelayTime)
    {
        
        yield return new WaitForSeconds(NPCDelayTime);
        CheckMove = true;

    }

}
