using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text winText;
    public Text holeText;
    public Text parText;
    public Text scoreText;
    public GameObject ball;
    private float timer = 0;
    public GameObject[] startMats;
    public int levelNum;
    StrokeManager StrokeManager;
    private int totScore;


    void Start()
    {
        winText.text = " ";
        ball.transform.position = ball.transform.position = new Vector3(startMats[levelNum].transform.position.x, startMats[levelNum].transform.position.y + 1f, startMats[levelNum].transform.position.z);
        holeText.text = "Practice Round";
        parText.text = "Par: ---";
        scoreText.text = "Total Score: 0";
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.gameObject.layer == 8)
        {
            winText.text = "Nice Shot!!!";
            if (timer < 8)
            {
                timer += Time.deltaTime;
            }else if (timer >= 3)
            {
                
                if (timer >= 8)
                {
                    timer = 0;
                    totScore += StrokeManager.StrokeCount;
                    StrokeManager.StrokeCount = 0;
                    StrokeManager.StrokeAngle = 0;
                    levelNum++;
                    winText.text = "";
                    holeText.text = "Hole " + levelNum.ToString();
                    parText.text = "Par: ";
                    scoreText.text = "Total Score: " + totScore.ToString();

                    ball.transform.position = new Vector3(startMats[levelNum].transform.position.x, startMats[levelNum].transform.position.y + 1f, startMats[levelNum].transform.position.z);
                    ball.transform.rotation = startMats[levelNum].transform.rotation;
                    
                }
            }

        } else if (ball.gameObject.layer != 8)
        {
            timer = 0;
        }
    }
}
