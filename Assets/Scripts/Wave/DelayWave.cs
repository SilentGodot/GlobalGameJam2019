using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Wave
{
    class DelayWave : Wave
    {
        [SerializeField] public List<float> delays;

        private float timePassed;

        protected override bool Spawn()
        {
            if (!base.Spawn()) return false;
            if (Time.time - timePassed > delays[_currentSpawnCount])
            {
                int i = _currentSpawnCount;
                timePassed = Time.deltaTime;
                var enemy = _enemySettings[i].Prefab;
                var path = _enemySettings[i].Path;
                var fearScript = _enemySettings[i].FearScript;
                Instantiate<GameObject>(enemy);
                fearScript.Walker.spline = path;
                _fearInstances.Add(fearScript);
                enemy.SetActive(true);
                _currentSpawnCount++;
            }
            return true;
        }

        protected override void Start()
        {
            base.Start();
            isSpawning = true;
            timePassed = Time.deltaTime;
        }

        protected override void Update()
        {
            base.Update();
            Spawn();
        }

    }
}
