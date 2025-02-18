using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [Header("Rounds Configuration")]
    public List<Round_SO> Rounds;

    private int _currentRoundIndex = 0;
    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = Lateral_Movement.Instance._enemy;              /*HELP!!!!*/
        InitializeCurrentRound();
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void InitializeCurrentRound()
    {
        if (IsValidRoundIndex(_currentRoundIndex))
        {
            var currentRound = Rounds[_currentRoundIndex];
            currentRound.ResetWaveIndex();
            currentRound.InitializeAllWaves();
        }
    }

    private bool IsValidRoundIndex(int index) => index >= 0 && index < Rounds.Count;

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (!IsValidRoundIndex(_currentRoundIndex)) yield break;

            var currentRound = Rounds[_currentRoundIndex];
            var currentWave = currentRound.GetCurrentWave();

            if (currentWave != null)
            {
                foreach (var bloonData in currentWave.EnemyDatas)
                {
                    if (bloonData.Finished) continue;

                    if (bloonData.Time <= 0)
                    {
                        InstantiateBloon(bloonData, currentWave.MicroWave[currentWave.EnemyDatas.IndexOf(bloonData)]);
                    }
                    else
                    {
                        bloonData.Time -= Time.deltaTime;
                    }
                }

                if (currentWave.AllWavesFinished())
                {
                    currentRound.MoveToNextWave();
                }
            }

            if (currentRound.WavesEnded() && Lateral_Movement.Instance.ReturnEnemyCount() <= 0)
            {
                _currentRoundIndex++;
                InitializeCurrentRound();
            }

            yield return null;
        }
    }

    private void InstantiateBloon(EnemyData bloonData, MicroWaveData microWaveData)
    {
        var newBloon = Instantiate(microWaveData.Type, _spawnPoint.position, Quaternion.identity);
        bloonData.EnemyToSpawn--;
        Lateral_Movement.Instance.AddEnemy(newBloon);
        bloonData.Time = microWaveData.SpawnDelay;

        if (bloonData.EnemyToSpawn <= 0) bloonData.Finished = true;
    }
}

