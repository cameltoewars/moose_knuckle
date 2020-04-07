using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustableCameraController : MonoBehaviour
{
    float cameraDistance = 15.0f;

    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        Vector3 camPosition = players[0].transform.position;
        camPosition.y = cameraDistance;
        gameObject.transform.position = camPosition;
    }
}
