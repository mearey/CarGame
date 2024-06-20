using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Object enemy1prefab;
    public int spawnRate;
    public int timer;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= 1;
        if (timer <= 0)
        {
            GameObject enemy = (GameObject)Instantiate(enemy1prefab, transform.position, transform.rotation);
            timer = spawnRate;
        }
        
    }
}
