using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTiles : MonoBehaviour
{
    // Start is called before the first frame update

    float[ ] rotations = { 0.0f, 90.0f,180.0f,270.0f};


    public float[ ] CorrectRotation;
    [SerializeField]
    public bool isPlaced = false;

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

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == CorrectRotation[0] || transform.eulerAngles.z == CorrectRotation[1])
            {
                isPlaced = true;
                PuzzleManager.GetComponent<PuzzleManager>().CorrectMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == CorrectRotation[0])
            {
                isPlaced = true;
                PuzzleManager.GetComponent<PuzzleManager>().CorrectMove();
            }
        }

    }



    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90.0f));

        if(PossibleRots > 1)
        {

        
            if (transform.eulerAngles.z == CorrectRotation[0] || transform.eulerAngles.z == CorrectRotation[1] && isPlaced == false)
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
            if (transform.eulerAngles.z == CorrectRotation[0]&& isPlaced == false)
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
