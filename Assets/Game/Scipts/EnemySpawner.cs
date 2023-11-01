using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currentWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform SpawnLocation;
    public int waveDuration;
    public float waveTimer;
    public float spawnInetrval;
    public float spawntime;

    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawntime < 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], SpawnLocation.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawntime = spawnInetrval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawntime -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        spawnInetrval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randomEnemyID = Random.Range(0, enemies.Count);
            int randomEnemyCost = enemies[randomEnemyID].cost;

            if (waveValue - randomEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randomEnemyID].enemyPrefab);
                waveValue -= randomEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;
    }
}