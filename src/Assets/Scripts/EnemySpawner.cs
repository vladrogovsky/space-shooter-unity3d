using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] List<WaveConfig> wavesList;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
	IEnumerator Start () {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }
    private IEnumerator SpawnAllWaves()
    {
         for (int waveIndex = startingWave; waveIndex < wavesList.Count; waveIndex++)
        {
            var currentWave = wavesList[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        for (int enemyCount = 0; enemyCount <= currentWave.GetNumberOfEnemies(); enemyCount++)
        {
            var OneEnemy = Instantiate(
                currentWave.GetEnemyPrefab(),
                currentWave.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            OneEnemy.GetComponent<EnemyPathing>().SetWaveConfig(currentWave);
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpaws());
        }
    }
}
