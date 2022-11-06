using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 50f;    // Acceleration
    [SerializeField] float MaxSpeed = 15; 
    [SerializeField] float Drag = 0.98f;
    [SerializeField] float SteerAngle = 20f;
    [SerializeField] float Traction = 1f;

     /* Update in order as soon as is changed:
     First: 50, 25, 0.9975
     Second: 50, 30, 0.995, 20
     Third: 50, 30, 0.998, 25
     Fourth: 50, 30, 0.9985, 25, 1
     */

    private Vector3 MoveForce;  // Speed

    // Update is called once per frame
    void Update()
    {
        // Moving Forward
        MoveForce += transform.up * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // Turning
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        MoveForce *= Drag;
        // MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed); // not sure that I needed this after all
   
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.up, Traction * Time.deltaTime) * MoveForce.magnitude;
    }
}
