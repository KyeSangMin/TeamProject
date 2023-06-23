using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{


    public GameObject TileseHolder;
    public GameObject[ ] Tiles;

    public int puzzleNum;

    [SerializeField]
    int totalTiles = 0;
    [SerializeField]
    int CorrectedTiles = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        totalTiles = TileseHolder.transform.childCount;

        Tiles = new GameObject[totalTiles];
        
        for(int i = 0; i <Tiles.Length; i++)
        {
            Tiles[i] = TileseHolder.transform.GetChild(i).gameObject;
        }


    }

    public void CorrectMove()
    {
        CorrectedTiles += 1;
        Debug.Log("correcedmove");
        Debug.Log(CorrectedTiles);
        if (CorrectedTiles == totalTiles)
        {
            switch(puzzleNum)
            {

                case 1:
                    GameObject.Find("SceneManage").GetComponent<DataManager>().Door0to1 = true;
                    GameObject.Find("SceneManage").GetComponent<DataManager>().DestroyPuzzle();
                    break;

                case 2:
                    GameObject.Find("SceneManage").GetComponent<DataManager>().Door2to3 = true;
                    GameObject.Find("SceneManage").GetComponent<DataManager>().DestroyPuzzle();
                    break;

                case 3:
                    GameObject.Find("SceneManage").GetComponent<DataManager>().Door5to6 = true;
                    GameObject.Find("SceneManage").GetComponent<DataManager>().DestroyPuzzle();
                    break;
               

                default:
                    break;
            }
        }
    }

    public void WrongMove()
    {
        CorrectedTiles -= 1;
    }






    // Update is called once per frame
    void Update()
    {
        
    }
}
