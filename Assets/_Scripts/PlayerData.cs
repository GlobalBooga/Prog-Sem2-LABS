using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public PlayerData()
    {
        playerPosition = Vector3.zero;
        playerRotation = Quaternion.identity;
    }

    public Vector3 playerPosition;
    public Quaternion playerRotation;
}
