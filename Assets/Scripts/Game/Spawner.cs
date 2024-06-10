using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform playerTransform;
    public float spawnRadius = 30f;
    public float initialDelay = 10f;
    public float spawnInterval = 10f;
    public float difficultyIncreaseRate = 0.1f;
    public float maxSpawnInterval = 5f;

    private bool spawning = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemiesWithDelay(initialDelay));
    }

    IEnumerator SpawnEnemiesWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spawning = true;

        while (spawning)
        {
            SpawnWaveOfEnemies();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnWaveOfEnemies()
    {
        // Calcula la posición de spawn al azar dentro del radio alrededor del jugador
        Vector3 spawnPosition = playerTransform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0; // Asegura que los enemigos se spawnearán en el mismo plano que el jugador

        // Elige un prefab de enemigo al azar de la lista
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Instancia un nuevo enemigo en la posición de spawn
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Incrementa la dificultad aumentando el intervalo de spawn
        spawnInterval -= difficultyIncreaseRate;
        spawnInterval = Mathf.Clamp(spawnInterval, maxSpawnInterval, spawnInterval);
    }

    public void StopSpawning()
    {
        spawning = false;
    }
}