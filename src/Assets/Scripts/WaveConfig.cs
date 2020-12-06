using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject PathPrefab;
    [SerializeField] float timeBetweenSpaws = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return EnemyPrefab;
    }
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform Waypoint in PathPrefab.transform)
        {
            waveWaypoints.Add(Waypoint);
        }
        return waveWaypoints;
    }
    public float GetTimeBetweenSpaws()
    {
        return timeBetweenSpaws;
    }
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
}
