using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : PowerUp
{
    public override void ApplyPowerUp(GameObject player)
    {
        Debug.Log("Damage increased");
    }
}