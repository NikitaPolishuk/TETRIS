using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameLogic : MonoBehaviour
{

    public float dropTime = 0.9f;
    public static float quickDropTime = 0.05f;

    public static int width = 15, height = 40;
    public List<GameObject> blocks;
    public Transform[,] grid = new Transform[width, height];

    public GameObject SpeedText;


    private void Awake()
    {
        blocks = BlockManager.instance.blocks;
    }

    void Start()
    {


        SpawnBlock();

        
    }
    void Update()
    {

    }

    
    public void ClearLines()
    {

        for (int y = 0; y < height; y++)
        {
            if (IsLineComplete(y))
            {

                DestroyLine(y);
                MoveLines(y);

                ScoreScript.instance.Score();

                acceleration();


            }
        }

    }

    public void acceleration()
    {


        if (ScoreScript.score == 30)
        {
            dropTime -= 0.150f;
            SpeedText.GetComponent<Text>().text = "Score: 2";
        }

        if (ScoreScript.score == 60)
        {
            dropTime -= 0.150f;
            SpeedText.GetComponent<Text>().text = "Score: 3";
        }

        if (ScoreScript.score == 90)
        {
            dropTime -= 0.150f;
            SpeedText.GetComponent<Text>().text = "Score: 4";
        }

        if (ScoreScript.score == 120)
        {
            dropTime -= 0.150f;
            SpeedText.GetComponent<Text>().text = "Score: 4";
        }

        if (ScoreScript.score == 150)
        {
            dropTime -= 0.150f;
            SpeedText.GetComponent<Text>().text = "Score: MAX";
        }
    }



    void MoveLines(int y)
    {
        for (int i = y; i < height - 1; i++)

        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, i + 1] != null)

                {
                    grid[x, i] = grid[x, i + 1];
                    grid[x, i].gameObject.transform.position -= new Vector3(0, 1, 0);
                    grid[x, i + 1] = null;
                }
            }
        }
    }

    void DestroyLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;

        }
    }

    bool IsLineComplete(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }




    public void SpawnBlock()
    {


        float guess = Random.Range(0, 1f);
        guess *= blocks.Count;
        Instantiate(blocks[Mathf.FloorToInt(guess)]);



    }


}
