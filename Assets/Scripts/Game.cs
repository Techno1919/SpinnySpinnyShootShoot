using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openedDoor;
    public bool gameOver = false;
    public bool gameWin = false;
    public int score = 0;
    public Text scoreText;
    public GameObject youWin;
    public GameObject youLose;
    public GameObject playAgain;

    static Game instance;
    static public Game Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Game>();
            }
            return instance;
        }
    }

    Enemy[] enemies;

    private void Start()
    {
        youWin.SetActive(false);
        youLose.SetActive(false);
        playAgain.SetActive(false);
    }

    void Update()
    {
        scoreText.text = $"Score: {score}";

        enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length <= 0)
        {
            gameWin = true;

            /*closedDoor.SetActive(false);
            openedDoor.SetActive(true);*/
        }

        if(gameWin)
        {
            youWin.SetActive(true);
            playAgain.SetActive(true);
        }
        if(gameOver)
        {
            youLose.SetActive(true);
            playAgain.SetActive(true);
        }
    }
}