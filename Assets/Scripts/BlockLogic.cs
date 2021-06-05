using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockLogic : MonoBehaviour
{
    bool movable = true;
    bool moved = false;
    float timer = 0f;
    public GameObject rig;
    GameLogic gameLogic;
    public Transform[,] grid = new Transform[15, 31];

    private int touchSensetivityHorizonl = 30;
    private int touchSensetivityVertical = 10;

    Vector2 previousUnitPosition = Vector2.zero;
    Vector2 direction = Vector2.zero;

    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();

    }


    public void RegisterBlock()
    {
        foreach (Transform subBlock in rig.transform)
        {
            gameLogic.grid[Mathf.FloorToInt(subBlock.position.x), Mathf.FloorToInt(subBlock.position.y)] = subBlock;

        }

    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }

        CheckEndGame();
    }

    void GameOver()
    {
        gameLogic.dropTime = 0.9f;
        SceneManager.LoadScene(2);
    }


    void CheckEndGame()
    {

        for (int j = 0; j < 15; j++)
        {

            if (grid[j, 28] != null)
            {

                GameOver();
            }
        }
    }



    bool CheckValid()
    {
        foreach (Transform subBlock in rig.transform)
        {
            if (subBlock.transform.position.x >= GameLogic.width ||
                subBlock.transform.position.x < 0 ||
                subBlock.transform.position.y < 0)

            {
                return false;
            }
            if (subBlock.position.y < GameLogic.height && gameLogic.grid[Mathf.FloorToInt(subBlock.position.x), Mathf.FloorToInt(subBlock.position.y)] != null)
            {
                return false;
            }
        }
        return true;

        
    }


    void Update()
    {
        //CheckUserInput();

        Swipe();

        gameLogic.ClearLines();

        



    }

    void Swipe()
    {
        if (movable && Time.deltaTime > 0)
        {
            timer += 1 * Time.deltaTime;

            if (timer > gameLogic.dropTime)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                timer = 0;
                if (!CheckValid())
                {
                    movable = false;
                    gameObject.transform.position += new Vector3(0, 1, 0);
                    RegisterBlock();
                    AddToGrid();
                    gameLogic.SpawnBlock();
                }

            }

            if (Input.touchCount > 0)

            {

                Touch t = Input.GetTouch(0);

                if (t.phase == TouchPhase.Began)
                {
                    previousUnitPosition = new Vector2(t.position.x, t.position.y);
                }

                else if (t.phase == TouchPhase.Moved)
                {


                    Vector2 touchDeltaPosition = t.deltaPosition;
                    direction = touchDeltaPosition.normalized;



                    if (Mathf.Abs(t.position.x - previousUnitPosition.x) >= touchSensetivityHorizonl && direction.x < 0 && t.deltaPosition.y > -10 && t.deltaPosition.y < 10)
                    {
                        gameObject.transform.position -= new Vector3(1, 0, 0);

                        if (!CheckValid())
                        {

                            gameObject.transform.position += new Vector3(1, 0, 0);

                        }
                        previousUnitPosition = t.position;
                        moved = true;

                    }
                    else if (Mathf.Abs(t.position.x - previousUnitPosition.x) >= touchSensetivityHorizonl && direction.x > 0 && t.deltaPosition.y > -10 && t.deltaPosition.y < 10)
                    {
                        //right
                        gameObject.transform.position += new Vector3(1, 0, 0);
                        if (!CheckValid())
                        {

                            gameObject.transform.position -= new Vector3(1, 0, 0);
                        }
                        previousUnitPosition = t.position;
                        moved = true;

                    }

                    else if ((Mathf.Abs(t.position.y - previousUnitPosition.y) >= touchSensetivityVertical && direction.y < 0 && t.deltaPosition.x > -10 && t.deltaPosition.x < 10)&& timer > GameLogic.quickDropTime)
                    {

                        //down
                        gameObject.transform.position -= new Vector3(0, 1, 0);

                        if (!CheckValid())
                        {
                            movable = false;
                            gameObject.transform.position += new Vector3(0, 1, 0);
                            RegisterBlock();
                            AddToGrid();
                            gameLogic.SpawnBlock();

                        }

                        previousUnitPosition = t.position;
                        moved = true;
                    }

                }
                else if (t.phase == TouchPhase.Ended)
                {
                    if (!moved && t.position.x > Screen.width / 4)
                    {
                        rig.transform.eulerAngles -= new Vector3(0, 0, 90);

                        if (!CheckValid())
                        {

                            rig.transform.eulerAngles += new Vector3(0, 0, 90);
                        }
                    }
                    moved = false;
                }
            }


        }
    }




    //void CheckUserInput()
    //{

    //    if (movable && Time.deltaTime > 0)
    //    {
    //        timer += 1 * Time.deltaTime;


    //        if (Input.GetKey(KeyCode.DownArrow) && timer > GameLogic.quickDropTime)
    //        {



    //            gameObject.transform.position -= new Vector3(0, 1, 0);
    //            timer = 0;
    //            if (!CheckValid())
    //            {
    //                movable = false;
    //                gameObject.transform.position += new Vector3(0, 1, 0);
    //                RegisterBlock();
    //                AddToGrid();
    //                gameLogic.SpawnBlock();

    //            }
    //        }

    //        else if (timer > gameLogic.dropTime)
    //        {
    //            gameObject.transform.position -= new Vector3(0, 1, 0);
    //            timer = 0;
    //            if (!CheckValid())
    //            {
    //                movable = false;
    //                gameObject.transform.position += new Vector3(0, 1, 0);
    //                RegisterBlock();
    //                AddToGrid();
    //                gameLogic.SpawnBlock();
    //            }

    //        }

    //        if (Input.GetKeyDown(KeyCode.LeftArrow))
    //        {

    //            gameObject.transform.position -= new Vector3(1, 0, 0);

    //            if (!CheckValid())
    //            {

    //                gameObject.transform.position += new Vector3(1, 0, 0);

    //            }
    //        }
    //        else if (Input.GetKeyDown(KeyCode.RightArrow))
    //        {
    //            gameObject.transform.position += new Vector3(1, 0, 0);
    //            if (!CheckValid())
    //            {

    //                gameObject.transform.position -= new Vector3(1, 0, 0);
    //            }
    //        }

    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            rig.transform.eulerAngles -= new Vector3(0, 0, 90);

    //            if (!CheckValid())
    //            {

    //                rig.transform.eulerAngles += new Vector3(0, 0, 90);
    //            }
    //        }

    //    }

    //}


}
