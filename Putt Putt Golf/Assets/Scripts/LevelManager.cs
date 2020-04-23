using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text winText;
    public Text holeText;
    public Text parText;
    public GameObject ball;
    private float timer = 0;
    public GameObject[] startMats;
    public int levelNum;

    void Start()
    {
        winText.text = "";
        ball.transform.position = startMats[levelNum].transform.position;
        holeText.text = "Practice Round";
        parText.text = "Par: 99";
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.gameObject.layer == 8)
        {
            if (timer < 8)
            {
                timer += Time.deltaTime;
            }else if (timer >= 3)
            {
                winText.text = "Nice Shot!";
                if (timer >= 8)
                {
                    timer = 0;
                    levelNum++;
                    winText.text = "";
                    holeText.text = "Hole " + levelNum.ToString();
                    parText.text = "Par: ";
                    
                    ball.transform.position = startMats[levelNum].transform.position;
                }
            }

        } else if (ball.gameObject.layer != 8)
        {
            timer = 0;
        }
    }
}
