using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public float ammoCount;
    public float effectiveRange;
    public float drawSpeed;
    public float weight;

    public Transform hand;
    public Vector3 rotationInHand;
    //public AnimationClip shootAnimation;


    internal virtual void Start()
    {
        
    }

    internal virtual void Update()
    {
        transform.position = hand.position;
        transform.rotation = Quaternion.Euler(hand.eulerAngles + rotationInHand);
    }

    internal virtual void Shoot()
    {

    }

    internal virtual void Aim()
    {

    }

}
