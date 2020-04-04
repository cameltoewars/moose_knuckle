using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOrbitRotation : MonoBehaviour
{
    public float orbitSpeed;
 
    // Update is called once per frame
    void Update()
    {
        Vector3 orbitOriginPoint = new Vector3(500, 0, 0);
        Vector3 axis = new Vector3(0, 0, 1);
        transform.RotateAround(orbitOriginPoint, axis, orbitSpeed * Time.deltaTime);
    }
}
