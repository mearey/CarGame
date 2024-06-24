using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject car;
    public Rigidbody carRb;
    public Vector3 carVelocity;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        carRb = car.GetComponent<Rigidbody>();
        carVelocity = carRb.velocity*0.02f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += this.transform.forward * projectileSpeed + carVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(this);
            Debug.Log(collision.gameObject.tag);
        }
        
    }
}
