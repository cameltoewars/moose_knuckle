using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    double distanceScale = 1000000.0;
    double bodyMass;
    void Awake()
    {
        bodyMass = 0.4e24 * transform.localScale.x * transform.localScale.x;
    }
    
    void FixedUpdate()
    {
        
        
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            Vector3 forceDirection = gameObject.transform.position - player.transform.position;
            Rigidbody rb = player.GetComponent(typeof(Rigidbody)) as Rigidbody;
            double G = 6.67e-11;
            
            double forceMagnitude = (G * bodyMass * rb.mass) / System.Math.Pow(forceDirection.magnitude * distanceScale, 2);

            forceDirection.Normalize();
            rb.AddForce(forceDirection * (float)forceMagnitude * Time.deltaTime);
        }
    }
}
