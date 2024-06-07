using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public float hP = 100f;
    public float damage = 1f;
    public float attackSpeed = 1f;
    public bool playerAlive = true;

    private Animator playerAnimator;
    PlayerMovement playerMovement;

    Rigidbody rb;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure the player manager persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>(true);
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    public void ResetPlayer()
    {
        hP = 100f;
        damage = 1f;
        attackSpeed = 1f;
        playerAlive = true;
        playerMovement.enabled = true;

        if (!rb.isKinematic)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    public void LoseHealth(float value)
    {
        hP -= value;
        if (hP < 0)
        {
            hP = 0;
            Debug.Log("Death");
            DeathAnimation();
            playerMovement.enabled = false;
            playerAlive = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    } // Recive Damage

    public void Heal(float value)
    {
        if (playerAlive)
        {
            hP += value;
            if (hP > 100)
            {
                hP = 100f;
            }
        }
    } // Restore Health

    public void IncreaseAttackSpeed(float value)
    {
        attackSpeed -= value;
        if (attackSpeed < 0.1f)
        {
            attackSpeed = 0.1f;
        }
    } // Increase Attack Speed

    public void DecreaseAttackSpeed(float value)
    {
        attackSpeed += value;
        if (attackSpeed > 1f)
        {
            attackSpeed = 1f;
        }
    } // Lower Attack Speed

    public void IncreaseDamage(float value)
    {
        damage += value;
        if (damage > 10f)
        {
            damage = 10f;
        }
    } // Increase Damage

    public void LowerDamage(float value)
    {
        damage -= value;
        if (damage < 1f)
        {
            damage = 1f;
        }
    } // Decrease Damage

    public Animator GetAnimator()
    {
        return playerAnimator;
    } // Assigns the animator to the script which calls it

    public void ShootAnimation()
    {
        playerAnimator.SetTrigger("shoot");
    }

    public void DeathAnimation()
    {
        if (playerAlive)
        {
            playerAnimator.SetTrigger("death");
        }
    }
}
