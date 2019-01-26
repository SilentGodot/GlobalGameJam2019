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

        private float timeDelta;

        protected override bool Spawn()
        {
            if (!base.Spawn()) return false;
            if (Time.time - timeDelta > delays[_currentSpawnCount])
            {
                int i = _currentSpawnCount;
                SpawnEnemy(i);
            }
            return true;
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
            Spawn();
        }

        public override void StartSpawn()
        {
            base.StartSpawn();
            isSpawning = true;
            timeDelta = Time.time;
        }
    }
}
