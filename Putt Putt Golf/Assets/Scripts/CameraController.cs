using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject golfBall;
    public GameObject arrow;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - golfBall.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = golfBall.transform.position + offset;
        transform.rotation = Quaternion.Euler(0, 100 * arrow.transform.rotation.y , 0);
    }
}