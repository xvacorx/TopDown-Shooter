using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedPowerUp : PowerUp
{
    public override void ApplyPowerUp(GameObject player)
    {
        Debug.Log("Attack Speed Increased");
    }
}