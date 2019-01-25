using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Wave
{
    class BatchWave : Wave
    {
        protected override bool Spawn()
        {
            if (!base.Spawn()) return false;
            for (int i = 0; i < _enemySettings.Count; i++)
            {
                SpawnEnemy(i);
            }
            return true;
        }

        //protected override void Start()
        //{
        //    base.Start();
        //}

        //protected override void Update()
        //{
        //    base.Update();
        //    if (Input.GetKeyDown(KeyCode.X))
        //    {
        //        isSpawning = true;
        //        Spawn();
        //    }
        //}

    }
}
