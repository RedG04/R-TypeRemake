using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WaveSO", order = 1)]
public class Wave_SO : ScriptableObject
{
    public List<MicroWaveData> MicroWave;
    public List<EnemyData> EnemyDatas { get; private set; }

    public void InitializeBloonData()
    {
        EnemyDatas = new List<EnemyData>();
        foreach (var waveData in MicroWave)
        {
            EnemyData newData = new EnemyData(waveData.Quantity, waveData.SpawnDelay);
            EnemyDatas.Add(newData);
        }
    }

    public bool AllWavesFinished() => EnemyDatas.TrueForAll(bloon => bloon.Finished);
}

public class EnemyData
{
    public int EnemyToSpawn { get; set; }
    public float Time { get; set; }
    public bool Finished { get; set; }

    public EnemyData(int enemyToSpawn, float time)
    {
        EnemyToSpawn = enemyToSpawn;
        Time = time;
        Finished = false;
    }
}

[System.Serializable]
public struct MicroWaveData
{
    public Lateral_Movement Type;
    [Range(0, 100)] public int Quantity;
    [Range(0, 3)] public float SpawnDelay;
}