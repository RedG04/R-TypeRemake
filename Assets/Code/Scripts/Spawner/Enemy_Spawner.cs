using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    //[Header("Rounds Configuration")]
    //public List<Round_SO> Rounds;
    //public List<Transform> Spawns;

    //private int _currentRoundIndex = 0;
    //private Transform _spawnPoint;

    //private Transform GetRandomSpawnpoint()
    //{
    //    int RandomIndex = Random.Range(0, Rounds.Count);
    //    return Spawns[RandomIndex];
    //}
public class Enemy_Spawner : MonoBehaviour
{
    public Round_SO roundSO; // Oggetto che contiene le wave
    public Transform[] spawnPoints; // Punti di spawn per i nemici
    public float waveDelay = 2f; // Tempo di attesa tra una wave e l'altra

    private Wave_SO _currentWave;
    private List<GameObject> _activeEnemies = new List<GameObject>(); // Lista di nemici attivi

    void Start()
    {
        roundSO.ResetWaveIndex(); // Reset dell'indice delle wave all'inizio
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        // Ottieni la wave corrente dal Round_SO
        _currentWave = roundSO.GetCurrentWave();
        //Debug.Log("Wave corrente: " + _currentWave);

        if (_currentWave != null)
        {
            // Inizializza i dati della wave
            _currentWave.InitializeEnemy();

            // Loop per spawnare tutti i nemici della wave
            for (int i = 0; i < _currentWave.enemyCount; i++)
            {
                // Ottieni un punto di spawn casuale
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Instanzia il nemico
                GameObject enemy = Instantiate(_currentWave.enemyPrefab, spawnPoint.position, Quaternion.identity);

                // Aggiungi il nemico alla lista degli attivi
                _activeEnemies.Add(enemy);

                // Assicurati che il nemico invii un messaggio quando viene distrutto
                enemy.GetComponent<Enemy_Health>().OnDeath += () => _activeEnemies.Remove(enemy);

                // Ritardo tra i spawn
                yield return new WaitForSeconds(_currentWave.spawnDelay);
            }

            // Aspetta che tutti i nemici siano morti prima di passare alla wave successiva
            yield return new WaitUntil(() => _activeEnemies.Count == 0);

            // Dopo che tutti i nemici sono morti, passa alla wave successiva
            yield return new WaitForSeconds(waveDelay);

            // Passa alla wave successiva
            roundSO.MoveToNextWave();
            //Debug.Log("Passando alla wave successiva. Wave index: " + roundSO._currentWaveIndex);

            // Se ci sono altre wave, inizia la prossima wave
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
