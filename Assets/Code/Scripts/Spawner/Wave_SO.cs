using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "ScriptableObjects/WaveSO", order = 2)]
public class Wave_SO : ScriptableObject
{
    public int enemyCount; // Number of enemy to spawn
    public GameObject enemyPrefab; // Prefab of the enemy
    public float spawnDelay = 0.5f;
    private int _currentEnemyIndex = 0;

    public void InitializeEnemy()
    {
        _currentEnemyIndex = 0; // Reset of index enemy when the wave start
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