using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutterMovement : MonoBehaviour
{
    StrokeManager StrokeManager;
    // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StrokeManager.StrokeMode == StrokeManager.StrokeModeEnum.POWERING)
        {
            this.transform.rotation = Quaternion.Euler(StrokeManager.powerPercent * 10f, this.transform.rotation.y, 0);
        }
    }
}
