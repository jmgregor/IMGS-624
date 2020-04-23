using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    //public Text winText;
    LevelManager LevelManager;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //winText.text = "Game Over";
            LevelManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
