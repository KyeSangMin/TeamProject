using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{


    public float movetime=0.01f;
    Vector3 camPos;
    public float smoothTime = 0.1f;
    public bool ShackCheck;

    //ī�޶� ����
    //���� �ڵ� ��ó: https://chameleonstudio.tistory.com/55

    public float ShakeAmount;
    //��鸮�� ����

    public float ShakeTime;
    //��鸮�� �ð� 0�̻����� ������ �ٷ� Shake ����

    // Start is called before the first frame update
    void Start()
    {

        ShackCheck = false;
        camPos = this.GetComponent<Transform>().position;

        //cam = this.GetComponent<Camera>();
      
    }

    // Update is called once per frame
    void Update()
    {


       
            
            this.transform.position = camPos;
            ShakeCam();
     
        
       


    }

    void ShakeCam()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + transform.position;

            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
        }

    }

   
}
