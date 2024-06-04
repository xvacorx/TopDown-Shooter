using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float hP;
    public float damage;
    public float attackSpeed;

    public void LoseHealth(float value)
    {
        hP -= value;
        if (hP < 0) { Debug.Log("Death"); }
    } // Recive Damage
    public void Heal(float value)
    {
        hP += value;
        if (hP >= 100) { hP = 100f; }
    } // Restore Health
    public void IncreaseAttackSpeed(float value)
    {
        attackSpeed -= value;
        if (attackSpeed <= 0.1f) { attackSpeed = 0.1f; }
    } // Increase Attack Speed
    public void DecreaseAttackSpeed(float value)
    {
        attackSpeed += value;
        if (attackSpeed >= 1f) { attackSpeed = 1f; }
    } // Lower Attack Speed
    public void IncreaseDamage(float value)
    {
        damage += value;
        if (damage >= 10f) { damage = 10f; }
    } // Increase Damage
    public void LowerDamage(float value)
    {
        damage -= value;
        if (damage <= 1f) { damage = 1f; }
    } // Decrease Damage
}