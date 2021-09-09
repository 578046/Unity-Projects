using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropell : MonoBehaviour
{
    public GameObject propeller;

    // Update is called once per frame
    void Update()
    {
        //rotates 150 degrees per second around z axis
        propeller.transform.Rotate(0, 0, 150 * Time.deltaTime);
    }
}
