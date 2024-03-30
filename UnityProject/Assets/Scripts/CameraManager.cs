using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject focus;
    public float distance = 5f;
    public float height = 2f;
    public float dampening = 1f;
    public Camera cam;
    public Rigidbody car;
    public CarController carCon;
    public InputManager im;

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (carCon.airborn)
        {
            transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)), dampening/3);
        } else
        {
            transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)), dampening);
        }
        transform.LookAt(focus.transform);
        if (carCon.boosting)
        {
            cam.fieldOfView =  Mathf.Lerp(cam.fieldOfView, 60 + 1.5f*car.velocity.magnitude / 2, 0.2f);
        } else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60 + car.velocity.magnitude / 2, 0.2f);
        }
    }
}
