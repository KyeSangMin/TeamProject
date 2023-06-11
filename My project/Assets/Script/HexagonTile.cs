using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonTile : MonoBehaviour
{
    // Start is called before the first frame update
    float[] rotations = {0.0f,60.0f,120.0f,180.0f,240.0f,300.0f};
    int[] rotateIndex = { 0, 1, 2, 3, 4, 5};

    public float[] CorrectRotation;
    [SerializeField]
    public bool isPlaced = false;


    public int isrotateIndex;
    public int CorrectIndex;


    public int[] CorrectRotate;



    int PossibleRots = 1;

    GameObject PuzzleManager;

    private void Awake()
    {
        PuzzleManager = GameObject.Find("PuzzleManager");
    }

    private void Start()
    {
        PossibleRots = CorrectRotation.Length;
        

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
        //transform.Rotate(new Vector3(0, 0, rotations[rand]));
        CorrectIndex = rand;
        isrotateIndex = rotateIndex[rand];
     //   Debug.Log(rand);

        if (PossibleRots > 1)
        {
            if (isrotateIndex == CorrectRotate[0] || isrotateIndex == CorrectRotate[1])
            {
                isPlaced = true;
                PuzzleManager.GetComponent<PuzzleManager>().CorrectMove();
            }
        }
        else
        {
            if (isrotateIndex == CorrectRotate[0])
            {
                isPlaced = true;
                PuzzleManager.GetComponent<PuzzleManager>().CorrectMove();
            }
        }

        /*

        
        if (PossibleRots > 1)
        {
            if (transform.rotation.z == CorrectRotation[0] || transform.rotation.z == CorrectRotation[1])
            {
                isPlaced = true;
                PuzzleManager.GetComponent<PuzzleManager>().CorrectMove();
            }
        }
        else
        {
            if (transform.rotation.z == CorrectRotation[0])
            {
                isPlaced = true;
                PuzzleManager.GetComponent<PuzzleManager>().CorrectMove();
            }
        }
        */
    }



    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 60.0f));
       
       
        
        if(CorrectIndex < 5)
        {
            CorrectIndex++;
          
        }
        else 
        {
            CorrectIndex = 0;

        }
        
        isrotateIndex = rotateIndex[CorrectIndex];

        if (PossibleRots > 1)
        {
            if (isrotateIndex == CorrectRotate[0] || isrotateIndex == CorrectRotate[1] && isPlaced == false)
            {
                isPlaced = true;
                PuzzleManager.GetComponent<PuzzleManager>().CorrectMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                PuzzleManager.GetComponent<PuzzleManager>().WrongMove();
            }
        }

        else
        {
            if (isrotateIndex == CorrectRotate[0] && isPlaced == false)
            {
                isPlaced = true;
                PuzzleManager.GetComponent<PuzzleManager>().CorrectMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                PuzzleManager.GetComponent<PuzzleManager>().WrongMove();
            }
        }
    }


    
}
