﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody playerBallRB;
    public float StrokeAngle { get; protected set; }

    //Power Meter
    public float StrokePower { get; protected set; }
    float maxPower = 100f;
    public float powerPercent { get { return StrokePower / maxPower; } }
    public float fillTime = 10f;
    int fill = 1;


    public enum StrokeModeEnum { PUTT, POWERING, AIMING, ROLLING };
    public StrokeModeEnum StrokeMode { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        playerBallRB = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(StrokeMode == StrokeModeEnum.AIMING)
        {
            //change putt angle
            StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;

            //switch to powering up
            if (Input.GetButtonUp("Fire1"))
            {
                StrokeMode = StrokeModeEnum.POWERING;
                return;
            }

        }

        if(StrokeMode == StrokeModeEnum.POWERING)
        {
            //power meter fills up and back down
            StrokePower += (fillTime * fill) * Time.deltaTime;
            if(StrokePower > maxPower)
            {
                StrokePower = maxPower;
                fill = -1;
            } else if (StrokePower < 0)
            {
                StrokePower = 0;
                fill = 1;
            }
            //if hits button, shoot
            if (Input.GetButtonUp("Fire1"))
            {
                StrokeMode = StrokeModeEnum.PUTT;
            }
        }
    }
    
    void checkRolling()
    {
        if (playerBallRB.IsSleeping())
        {
            StrokeMode = StrokeModeEnum.AIMING;
        }
    }

    void FixedUpdate()
    {
        if (StrokeMode == StrokeModeEnum.ROLLING)
        {
            checkRolling();
            return;
        } else if (StrokeMode == StrokeModeEnum.PUTT)
        {
            StrokeMode = StrokeModeEnum.ROLLING;
            Vector3 forceVec = new Vector3(0, 0, StrokePower);
            playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * forceVec, ForceMode.Impulse);
            StrokePower = 0;
            fill = 1;
        } 
    }
}
