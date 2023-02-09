using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public float power;

    public GameObject bullet;
    public Transform bulletSpawn;


    internal virtual void Shoot()
    {
        GameObject b = Instantiate(bullet, bulletSpawn);
        b.GetComponent<Rigidbody>().AddForce(-transform.right * power, ForceMode.Impulse);
        b.transform.parent = null;
        Destroy(b, 5f);
    }

    internal virtual void Aim()
    {

    }

}
