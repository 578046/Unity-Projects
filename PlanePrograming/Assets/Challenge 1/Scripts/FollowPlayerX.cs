using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 desiredPositoin = plane.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPositoin, smoothSpeed);
        transform.position = smoothedPosition;
        
    }
}
