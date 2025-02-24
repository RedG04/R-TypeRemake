using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public Round_SO roundSO;
    public Transform[] spawnPoints;
    public float waveDelay = 2f;

    private Wave_SO _currentWave;
    private List<GameObject> _activeEnemies = new List<GameObject>(); // List activ enemy

    void Start()
    {
        roundSO.ResetWaveIndex();
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        _currentWave = roundSO.GetCurrentWave();
        //Debug.Log("Wave corrente: " + _currentWave);

        if (_currentWave != null)
        {
            // Inizializza i dati della wave
            _currentWave.InitializeEnemy();

            // Loop to spawn all enemies in the wave
            for (int i = 0; i < _currentWave.enemyCount; i++)
            {
                // Get a random spawnpoint
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                GameObject enemy = Instantiate(_currentWave.enemyPrefab, spawnPoint.position, Quaternion.identity);

                _activeEnemies.Add(enemy);

                // The enemey sends a massage when destroyed
                enemy.GetComponent<Enemy_Health>().OnDeath += () => _activeEnemies.Remove(enemy);

                yield return new WaitForSeconds(_currentWave.spawnDelay);
            }

            // Wait until all enemys are dead before the next wave
            yield return new WaitUntil(() => _activeEnemies.Count == 0);

            // After all enemies are dead, move on the next wave
            yield return new WaitForSeconds(waveDelay);

            // Move on the next wave
            roundSO.MoveToNextWave();
            //Debug.Log("Passando alla wave successiva. Wave index: " + roundSO._currentWaveIndex);

            // If there are wave, start the next wave
            if (!roundSO.WavesEnded())
            {
                StartCoroutine(SpawnWave());
            }
            else
            {
                Debug.Log("Round completato!");
            }
        }
    }
}
