using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class rotationScript : MonoBehaviour
{
    public GameObject gunMesh;
    public GameObject baseMesh;
    public GameObject baseMesh1;
    public GameObject[] AllEnemies;
    public GameObject nearestEnemy;
    public GameObject projectile;
    public int fireRate;
    float distance;
    float nearestDistance = 999;
    public int timer = 60;
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
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1, 1, 1), 0.2f);

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
            
            //firing code
            timer -= fireRate;
            if (timer <= 0 )
            {
                timer = 60;
                GameObject bullet = Instantiate(projectile, this.transform.position + Vector3.up*0.2f + Vector3.forward*0.1f, gunMesh.transform.rotation);
            }

        } else {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0, 0, 0), 0.2f);
        }
        
    }
}
