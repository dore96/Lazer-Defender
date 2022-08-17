using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WavesConfingsSO> wavesConfings;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping;
    WavesConfingsSO currWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WavesConfingsSO GetCurrWave()
    {
        return currWave;
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WavesConfingsSO wave in wavesConfings)
            {
                currWave = wave;
                for (int i = 0; i < currWave.GetEnemyCount(); i++)
                {
                    Instantiate(currWave.GetEnemyPrefab(i),
                        currWave.GetStartWayPoint().position,
                        Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
