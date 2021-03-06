﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleIndicator : MonoBehaviour
{
    StrokeManager StrokeManager;
    Transform ballTransform;

    // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        ballTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }



    // Update is called once per frame
    void Update()
    {
        this.transform.position = ballTransform.position;
        this.transform.rotation = Quaternion.Euler(0, StrokeManager.StrokeAngle, 0);
    }
}
