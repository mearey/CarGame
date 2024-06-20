using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WeaponManager : MonoBehaviour
{
    public GameObject startingWeapon;
    public GameObject currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = Instantiate(startingWeapon, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentWeapon.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
    }
}
