using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody Selfrb;
    public GameObject Player;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        Selfrb = GetComponent<Rigidbody>();
        Player = GameObject.Find("corolla");
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        transform.LookAt(Player.transform);

        Selfrb.AddForce(transform.forward * speed);
    }
}
