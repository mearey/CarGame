using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public bool brake;
    public bool boost;
    public CarController car;

    // Update is called once per frame
    void Update()
    {
        throttle = Input.GetAxis("Vertical");

        steer = Input.GetAxis("Horizontal");

        brake = Input.GetKey(KeyCode.Space);

        boost = Input.GetKey(KeyCode.LeftShift);
    }

    private void FixedUpdate()
    {
        //boost calculation
        if (car.drifting == 1.1f)
        {
            car.boost = car.boost + 0.1f;
        }
        if (car.airborn)
        {
            car.boost = car.boost + 0.5f;
        }
    }
}
