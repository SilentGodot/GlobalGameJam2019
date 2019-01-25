using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Wave
{
    public class Wave : MonoBehaviour
    {
        [SerializeField] public List<EnemySettings> _enemySettings;


        [SerializeField] protected int _spawnCount;
        protected int _currentSpawnCount;
                
        [Space]
        [Header("Spawn Pos")]
        protected Transform _spawnPositionTransform;


        protected bool isSpawning = false;
        [SerializeField] protected List<Fear> _fearInstances;

        protected virtual void Start()
        {
            _spawnPositionTransform = transform;
            _enemySettings = _enemySettings.Where(x => x != null).ToList();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
        }

        protected virtual bool Spawn()
        {
            if ((_enemySettings.Count == 0) ||
                (!isSpawning))
            {
                return false;
            }

            if (_spawnCount == _currentSpawnCount)
            {
                isSpawning = false;
                return false;
            }
            return true;
        }

        public bool IsDone()
        {
            var firstActiveInstance = _enemySettings.FirstOrDefault(x => x != null && x.Prefab.activeInHierarchy);
            return ((firstActiveInstance == null) && (_currentSpawnCount == _spawnCount));
        }


    }

    [Serializable]
    public class EnemySettings
    {
        [SerializeField] GameObject prefab;
        [SerializeField] BezierSpline path;
        [SerializeField] Fear fearScript;

        public GameObject Prefab
        {
            get
            {
                return prefab;
            }

            set
            {
                prefab = value;
            }
        }

        public BezierSpline Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public Fear FearScript
        {
            get
            {
                return fearScript;
            }

            set
            {
                fearScript = value;
            }
        }
    }
}
