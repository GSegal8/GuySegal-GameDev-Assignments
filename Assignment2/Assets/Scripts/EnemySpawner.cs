using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new();
    [SerializeField] private List<Transform> SpawnPoints = new();
    void Start()
    {
        Instantiate(enemies[Random.Range(0,enemies.Count)], SpawnPoints[0].position, Quaternion.identity);
    }
    

}
