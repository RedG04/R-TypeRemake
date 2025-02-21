using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoundSO", order = 1)]
public class Round_SO : ScriptableObject
{
    public List<Wave_SO> Waves;
    public int _currentWaveIndex;

    public void ResetWaveIndex() => _currentWaveIndex = 0;

    private bool IsValidWaveIndex(int index) => index >= 0 && index < Waves.Count;
    //public Wave_SO GetCurrentWave() => IsValidWaveIndex(_currentWaveIndex) ? Waves[_currentWaveIndex] : null;

    public Wave_SO GetCurrentWave()
    {
        if (_currentWaveIndex < Waves.Count)
        {
            return Waves[_currentWaveIndex]; // Restituisce la wave corrente
        }
        return null; // Nessuna wave disponibile
    }

    public void InitializeAllWaves()
    {
        foreach (var wave in Waves)
        {
            wave.InitializeEnemy();
        }
    }

    public void MoveToNextWave()
    {
        //if (GetCurrentWave()?.AllWavesFinished() == true && _currentWaveIndex < Waves.Count - 1)
        //{
            _currentWaveIndex++;
        //}
    }

    //public bool WavesEnded() => Waves.TrueForAll(wave => wave.AllWavesFinished());

    public bool WavesEnded()
    {
        return _currentWaveIndex >= Waves.Count; // Controlla se tutte le wave sono terminate
    }
}