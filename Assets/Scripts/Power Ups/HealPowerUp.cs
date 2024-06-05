using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : PowerUp
{
    public override void ApplyPowerUp(GameObject player)
    {
        Debug.Log("Healed");
    }
}
