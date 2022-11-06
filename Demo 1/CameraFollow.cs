using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// CAMERA CONTROLLER
public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    // this things position (camera) should be the same as the car's position
    // Start is called before the first frame update



    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10);
    }
}
