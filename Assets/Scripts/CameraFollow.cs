using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    Vector3 distance;

    public float smoothValue;

    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }


    void Follow()
    {
        Vector3 currentPos = transform.position;

        Vector3 cameraNewPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, cameraNewPos, smoothValue * Time.deltaTime);
    }
}
