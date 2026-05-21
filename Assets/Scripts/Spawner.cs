using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject prefabSpawn;
    public int numberSpawner = 10;

    public int SpawnerX = 10;
    public int SpawnerY = 0;
    public int SpawnerZ = 10;
    void Start()
    {
        for (int i = 0; i < numberSpawner; i++)
        {
            Spawn();
        }
    }
    void Spawn()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-SpawnerX, SpawnerX), Random.Range(-SpawnerY, SpawnerY), Random.Range(-SpawnerZ, SpawnerZ));
        GameObject clone = Instantiate(prefabSpawn, randomPosition, Quaternion.identity);
    }
}
