using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Configs", fileName = "New Wave Config")]
public class WavesConfingsSO : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeBetweenEnemies = 1f;
    [SerializeField] private float spawnTimeVariance = 0f;
    [SerializeField] private float minSpawnTime = 0.2f;

    public Transform GetStartWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }

        return wayPoints;
    }

    public float GetMove()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int ind)
    {
        return enemyPrefabs[ind];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemies - spawnTimeVariance,
            timeBetweenEnemies + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }

}
