using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putterStrokes : MonoBehaviour
{
    StrokeManager StrokeManager;
    // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //winText.text = "Game Over";
            StrokeManager.StrokeCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
