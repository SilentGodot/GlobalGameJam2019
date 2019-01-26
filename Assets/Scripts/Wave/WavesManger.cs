using Assets.Scripts.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManger : Events.Tools.MonoBehaviour_EventManagerBase, 
    Events.Groups.Level.Methods.IOnLevelStart,
    Events.Groups.Fear.IAll_Group_Events

{
    [SerializeField] uint goodEndThreshold;
    [SerializeField] List<Wave> waves;

    bool isStarted;
    uint fearDeathCount = 0;

    public void StartWave()
    {
        if (isStarted) return;
        isStarted = true;
        StartCoroutine("StartWaveC");
    }
    IEnumerator StartWaveC()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i] == null) continue;

            waves[i].StartSpawn();
            print("Wave " + i);
            yield return new WaitUntil(()=> waves[i].IsDone);
            waves[i].CleanAllEnemies();
            
        }

        // All waves finished! Go to ending
        if (fearDeathCount >= goodEndThreshold)
        {
            LevelManager.Instance.LoadScene("GoodEnd");
        }
        LevelManager.Instance.LoadScene("BadEnd");
    }


	

    public void OnLevelStart()
    {
         StartWave();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }

    public void FearDies()
    {
        fearDeathCount++;
    }
}
