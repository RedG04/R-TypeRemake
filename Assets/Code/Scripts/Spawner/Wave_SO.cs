using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "ScriptableObjects/WaveSO", order = 2)]
public class Wave_SO : ScriptableObject
{
    public int enemyCount; // Numero di nemici da spawnare
    public GameObject enemyPrefab; // Prefab del nemico
    public float spawnDelay = 0.5f; // Ritardo tra i colpi di nemico
    private int _currentEnemyIndex = 0;

    public void InitializeEnemy()
    {
        _currentEnemyIndex = 0; // Reset dell'indice nemico quando la wave inizia
    }

    public bool AllWavesFinished() => _currentEnemyIndex >= enemyCount;

    public void SpawnEnemy(Vector2 spawnPosition)
    {
        if (_currentEnemyIndex < enemyCount)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            _currentEnemyIndex++;
        }
    }
}