using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    public float firerate;

    internal override void Shoot()
    {
        //StartCoroutine(nameof(RapidFire));
    }

    //IEnumerator RapidFire()
    //{
    //    while (player.inputAction.Player.Shoot)
    //    {
    //
    //    }
    //}
}
