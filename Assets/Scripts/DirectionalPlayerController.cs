using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPlayerController : MonoBehaviour
{
    public float forwardThrust = 20.0f;
    public float rotationalThrust = 10.0f;

    void FixedUpdate()
    {
        float moveForward = Input.GetAxis("Vertical");
        float moveTurn = Input.GetAxis("Horizontal");

        Rigidbody rb = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
        rb.AddRelativeForce(new Vector3(0, 1.0f * forwardThrust * moveForward * Time.deltaTime, 0));
        rb.AddRelativeTorque(new Vector3(0, 0, rotationalThrust * moveTurn * Time.deltaTime));
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize - 1;
        }
        else if (scroll < 0f)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 1;
        }
    }
}
