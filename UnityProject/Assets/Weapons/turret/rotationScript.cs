using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationScript : MonoBehaviour
{
    public GameObject gunMesh;
    public GameObject baseMesh;
    public GameObject baseMesh1;
    public GameObject[] AllEnemies;
    public GameObject nearestEnemy;
    float distance;
    float nearestDistance = 999;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AllEnemies = GameObject.FindGameObjectsWithTag("enemy");
        if (AllEnemies.Length > 0)
        {
            for (int i = 0; i < AllEnemies.Length; i++)
            {
                distance = Vector3.Distance(this.transform.position, AllEnemies[i].transform.position);
                if (distance < nearestDistance)
                {
                    nearestEnemy = AllEnemies[i];
                    nearestDistance = distance;
                }
            }
            //rotate turret
            gunMesh.transform.LookAt(nearestEnemy.transform);
            //rotate base1
            baseMesh.transform.LookAt(nearestEnemy.transform);
            //rotate base2
            baseMesh1.transform.LookAt(nearestEnemy.transform);
        }
        
    }
}
