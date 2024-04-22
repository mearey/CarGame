using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public InputManager im;
    public UIManager uim;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> brakeWheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshes;
    public List<GameObject> emmiters;
    public List<Light> brakeLights;
    public float tourque;
    public float maxTurn;
    public float boostStrength;
    public Transform CM;
    public Rigidbody rb;
    public float brakeStrength;
    public float sideWheelFriction;
    public float forwardWheelFriction;
    public float drifting = 1;
    public ParticleSystem boostEmmiter;
    public bool airborn = false;
    public float boost = 50f;
    public float maxBoost = 100f;
    public Slider boostBar;
    public bool boosting = false;
    public bool driftingBool = false;
    public bool driving = false;
    void Start()
    {
        im = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();

        if (CM)
        {
            rb.centerOfMass = CM.position;
        }
        sideWheelFriction = throttleWheels[1].sidewaysFriction.stiffness;
        forwardWheelFriction = throttleWheels[1].forwardFriction.stiffness;

    }

    void Update()
    {
        //update boost on UI
        boostBar.value = boost/maxBoost;
        //drift sound changes based on angle
        if (Mathf.Abs(transform.InverseTransformDirection(rb.velocity).x) > 1)
        {
            driftingBool = true;
            
        } else
        {
            driftingBool = false;
            
        }
        //engine sound changes based on speed
        
        if (rb.velocity.magnitude / 20 + Mathf.Abs(transform.InverseTransformDirection(rb.velocity).x) / 100 < 0.2f)
        {
            driving = false;
        }
        else
        {
            driving = true;
        }

        //brakelights
        if (im.brake || im.throttle < 0)
        {
            foreach(Light light in brakeLights) 
            {
                light.intensity = 7;
            }
        } else
        {
            foreach (Light light in brakeLights)
            {
                light.intensity = 0.3f;
            }
        }
        if (Physics.Raycast(transform.position, -transform.up, 1))
        {
            airborn = false;
        } else
        {
            airborn = true;
        }

    }

    void FixedUpdate()
    {
        foreach (WheelCollider wheel in throttleWheels)
        {
            WheelFrictionCurve friction = wheel.sidewaysFriction;
            WheelFrictionCurve forwardFriction = wheel.forwardFriction;
            //BRAKING AND ACCELERAATING BEHAVIOUR
            if (im.brake)
            {
                if (brakeWheels.Contains(wheel))
                {
                    wheel.brakeTorque = brakeStrength;
                    wheel.motorTorque = 0f;
                }
                //set friction for drifing
                friction.stiffness = 1.2f;
                forwardFriction.stiffness = forwardWheelFriction + 4;
                wheel.sidewaysFriction = friction;
                wheel.forwardFriction = forwardFriction;
                drifting = 1.1f;
                /*if (!skidClip.isPlaying)
                {
                    skidClip.Play();
                }*/
            }
            else
            {
                if (im.boost && boost > 0)
                {
                    //boost fx
                    boostEmmiter.enableEmission = true;
                    wheel.motorTorque = tourque * Time.deltaTime * im.throttle * drifting * boostStrength;
                    boost -= 0.1f;
                    boosting = true;
                } else
                {
                    //boost fx
                    boostEmmiter.enableEmission = false;
                    wheel.motorTorque = tourque * Time.deltaTime * im.throttle * drifting;
                    boosting = false;
                }
                wheel.brakeTorque = 0f;
                if (Mathf.Abs(transform.InverseTransformDirection(rb.velocity).x) < 1 || airborn)
                {
                    friction.stiffness = sideWheelFriction;
                    forwardFriction.stiffness = forwardWheelFriction;
                    wheel.sidewaysFriction = friction;
                    wheel.forwardFriction = forwardFriction;
                    drifting = 1f;
                    //skidClip.Stop();
                }
            }
            //DRIFTING MARKS
            int index = throttleWheels.IndexOf(wheel);
            GameObject emmiter = emmiters[index];

            WheelHit hit = new WheelHit();

            wheel.GetGroundHit(out hit);
            if (hit.sidewaysSlip > .15 || hit.forwardSlip > .15 || hit.sidewaysSlip < -.15 || hit.forwardSlip < -.15)
            {
                emmiter.GetComponent<TrailRenderer>().emitting = true;
                if (emmiter.GetComponent<ParticleSystem>())
                {
                    emmiter.GetComponent<ParticleSystem>().enableEmission = true;
                }
            } else
            {
                emmiter.GetComponent<TrailRenderer>().emitting = false;
                if (emmiter.GetComponent<ParticleSystem>())
                {
                    emmiter.GetComponent<ParticleSystem>().enableEmission = false;
                }
            }
            uim.changeText
            (
            ""
            );
        }
        //ANTI ROLL TURNING
        foreach (GameObject wheel in steeringWheels)
        {
            RaycastHit groundRay;
            Physics.Raycast(transform.position, -transform.up, out groundRay, 1f);
            float groundTilt = groundRay.normal.y * 360;
            if (groundTilt > 180)
            {
                groundTilt = groundTilt - 360;
            }
            float tilt = rb.rotation.eulerAngles.z;
            int negative = 1; 
            if (rb.rotation.eulerAngles.z > 180)
            {
                tilt = 360 - rb.rotation.eulerAngles.z;
                negative = -1;
            } else
            {
                negative = 1;
            }
            //TILT less if the car is tilting
            if (!airborn && Mathf.Abs(groundTilt) < 10)
            {
                rb.AddTorque(transform.forward * tilt * -negative * 10);
            }
            //TURN less if the car is tilting but not if airborn
            float realTurn = maxTurn;
            if (tilt > 0.2 && Mathf.Abs(groundTilt) < 10)
            {
                realTurn = maxTurn / (tilt * 2);
            }
            wheel.GetComponent<WheelCollider>().steerAngle = realTurn * im.steer;
            wheel.transform.localEulerAngles = new Vector3(0f, im.steer * maxTurn + 90f, 0f);
            //if on tilted surface lock rotation of car
            if (Mathf.Abs(groundTilt) >= 10)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            } else
            {
                rb.constraints = RigidbodyConstraints.None;
            }
        }
        //DOWNFORCE CACLULATION
        rb.AddForce(transform.up * -rb.velocity.magnitude/4);
        foreach (GameObject wheel in meshes)
        {
            //MOVE WHEELS FOR STEERING AND DRVING
            float value;
            if (drifting == 1.1f)
            {
                value = 400/rb.velocity.magnitude / (20 * Mathf.PI * 0.011f);
            } else
            {
                value = rb.velocity.magnitude / (20 * Mathf.PI * 0.011f);
            }
            if (transform.InverseTransformDirection(rb.velocity).z >= 0)
            {
                wheel.transform.Rotate(0f, 0f, value);
            } else
            {
                wheel.transform.Rotate(0f, 0f, -value);
            }

        }
    }
}
