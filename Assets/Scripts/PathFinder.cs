using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WavesConfingsSO wavesConfing;
    private List<Transform> wayPoints;
    private int wayPointInd = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        wavesConfing = enemySpawner.GetCurrWave();
        wayPoints = wavesConfing.GetWayPoints();
        transform.position = wayPoints[wayPointInd].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wayPointInd < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointInd].position;
            float delta = wavesConfing.GetMove() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wayPointInd++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
