using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    public GameObject ball;
    private bool buttonPress = false;
    private Rigidbody playerBallRB;
    public float StrokeAngle { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        playerBallRB = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            buttonPress = true;
        }

        StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;
    }
    
    void FixedUpdate()
    {
        if (buttonPress)
        {
            buttonPress = false;
            Vector3 forceVec = new Vector3(0, 0, 1f);
            playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * forceVec, ForceMode.Impulse);
        } 
    }
}
