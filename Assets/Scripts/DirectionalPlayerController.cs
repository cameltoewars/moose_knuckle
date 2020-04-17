using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPlayerController : MonoBehaviour
{
    public float forwardThrust = 20.0f;
    public float rotationalThrust = 10.0f;
    Plane m_Plane;
    Camera m_MainCamera;

    void Start()
    {
        m_MainCamera = Camera.main;
        m_Plane = new Plane(Vector3.up, new Vector3(0,0,0));
    }

        void FixedUpdate()
    {
        float moveForward = Input.GetAxis("Vertical");
        float moveTurn = Input.GetAxis("Horizontal");

        Rigidbody rb = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
        rb.AddRelativeForce(new Vector3(-1.0f * forwardThrust * moveForward * Time.deltaTime,0 , 0));
        // rb.AddRelativeTorque(new Vector3(0, 0, rotationalThrust * moveTurn * Time.deltaTime));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;

        if (m_Plane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            Vector3 targetDir = transform.position - hitPoint;
            Vector3 localTarget = transform.InverseTransformDirection(targetDir);

            float angle = Mathf.Atan2(localTarget.y, localTarget.x) * Mathf.Rad2Deg;

            Vector3 eulerAngleVelocity = new Vector3(0, 0, angle);
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
            
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }


    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            m_MainCamera.orthographicSize = m_MainCamera.orthographicSize - 1;
        }
        else if (scroll < 0f)
        {
            m_MainCamera.orthographicSize = m_MainCamera.orthographicSize + 1;
        }
    }
}
