using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text winText;
    public Text holeText;
    public Text parText;
    public Text scoreText;
    public Text restartText;
    public Text totalScoreText;
    public GameObject ball;
    private float timer = 0;
    public GameObject[] startMats;
    public int levelNum;
    StrokeManager StrokeManager;
    private int totScore;
    public bool endGame { get; set; }
    bool restart;

    void Start()
    {
        winText.text = " ";
        restartText.text = " ";
        ball.transform.position = ball.transform.position = new Vector3(startMats[levelNum].transform.position.x, startMats[levelNum].transform.position.y + 1f, startMats[levelNum].transform.position.z);
        holeText.text = "Practice Round";
        parText.text = "Par: ---";
        scoreText.text = "Total Score: 0";
        totalScoreText.text = " ";
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        endGame = false;
        restart = false;
    }

    public void GameOver()
    {
        winText.text = "Good Game!!";
        restartText.text = "Press 'R' to restart!";
        totalScoreText.text = "Total Score: " + totScore.ToString();
        restart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.gameObject.layer == 8)
        {
            
            if (timer < 8)
            {
                timer += Time.deltaTime;
            }
            
            if (timer >= 3)
            {
                winText.text = "Nice Shot!!!";
                
                if (timer >= 8)
                {
                    timer = 0;
                    if(levelNum!= 0)
                    {
                        totScore += StrokeManager.StrokeCount;
                    }
                    StrokeManager.StrokeCount = 0;
                    StrokeManager.StrokeAngle = 0;
                    levelNum++;
                    winText.text = " ";
                    holeText.text = "Hole " + levelNum.ToString();
                    parText.text = "Par: 3";
                    scoreText.text = "Total Score: " + totScore.ToString();

                    ball.transform.position = new Vector3(startMats[levelNum].transform.position.x, startMats[levelNum].transform.position.y + 1f, startMats[levelNum].transform.position.z);
                    ball.transform.rotation = startMats[levelNum].transform.rotation;
                    
                }
            }

        } else if (ball.gameObject.layer != 8)
        {
            timer = 0;
        }

        if (levelNum == startMats.Length || endGame == true)
        {
            GameOver();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
                //Application.LoadLevel(Application.loadedLevel);
            }
        }

    }
}
