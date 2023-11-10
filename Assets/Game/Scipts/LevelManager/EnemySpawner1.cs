using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    private int waveValue = 5;
    private float spawnInterval = 2.0f;
    private float nextSpawn = 0f;
    public Transform spawnLocation;

    private List<Enemy> availableEnemies = new List<Enemy>();
    private int totalSpawnedCost = 0;

    [System.Serializable]
    public struct Enemy
    {
        [SerializeField]
        private GameObject enemyPrefab;
        [SerializeField]
        private int cost;

        public GameObject EnemyPrefab
        {
            get { return enemyPrefab; }
        }

        public int Cost
        {
            get { return cost; }
        }
    }


    void Start()
    {
        totalSpawnedCost = 0;
        UpdateAvailableEnemies();
    }

    void Update()
    {
            if (totalSpawnedCost < waveValue && Time.time >= nextSpawn)
            {
                SpawnEnemy();
                nextSpawn = Time.time + spawnInterval;
            }   
    }

    void UpdateAvailableEnemies()
    {
        availableEnemies.Clear();
        foreach (var enemy in enemies)
        {
            if (totalSpawnedCost + enemy.Cost <= waveValue)
            {
                availableEnemies.Add(enemy);
            }
        }
    }

    void SpawnEnemy()
    {
        if (availableEnemies.Count == 0)
        {
            Debug.LogWarning("No available enemy prefabs for the current budget.");
            return;
        }

        int randomIndex = Random.Range(0, availableEnemies.Count);
        Enemy selectedEnemy = availableEnemies[randomIndex];
        // Raise the spawn postion by 2 units
        Vector3 spawnPosition = spawnLocation.position + Vector3.up * 2.4f;

        Instantiate(selectedEnemy.EnemyPrefab, spawnPosition, spawnLocation.rotation);
        totalSpawnedCost += selectedEnemy.Cost;

        UpdateAvailableEnemies();
    }
}
