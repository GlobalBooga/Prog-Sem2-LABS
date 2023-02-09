using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public int shots = 5;

    internal override void Shoot()
    {
        float temp = power;   
        for (int i = 0; i < shots; i++)
        {
            GameObject b = Instantiate(bullet, bulletSpawn);
            b.GetComponent<Rigidbody>().AddForce(-transform.forward * power, ForceMode.Impulse);
            b.transform.parent = null;
            Destroy(b, 5f);
            temp -= 5;
        }
    }
}
