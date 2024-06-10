using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDrop : MonoBehaviour
{
    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;

    [Range(0, 1)]
    public float dropChance = 0.5f;
    private void OnDestroy()
    {
        TryDropPowerUp();
    }
    void TryDropPowerUp()
    {
        if (Random.value <= dropChance)
        {
            int powerUpIndex = Random.Range(0, 3);
            GameObject powerUpToDrop = null;

            switch (powerUpIndex)
            {
                case 0:
                    powerUpToDrop = powerUp1;
                    break;
                case 1:
                    powerUpToDrop = powerUp2;
                    break;
                case 2:
                    powerUpToDrop = powerUp3;
                    break;
            }

            if (powerUpToDrop != null)
            {
                Instantiate(powerUpToDrop, transform.position, Quaternion.identity);
            }
        }
    }
}