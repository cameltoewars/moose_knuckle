using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationsPerMinute;

    void Update()
    {
        transform.Rotate(0, 0, rotationsPerMinute * Time.deltaTime);
    }
}
