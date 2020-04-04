using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerObject;

    void FixedUpdate()
    {
        transform.position = new Vector3(playerObject.position.x, playerObject.position.y, transform.position.z);
    }
}
