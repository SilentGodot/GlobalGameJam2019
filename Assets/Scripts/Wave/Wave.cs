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


        protected int _spawnCount;
        protected int _currentSpawnCount = 0;
                
        [Space]
        [Header("Spawn Pos")]
        protected Transform _spawnPositionTransform;


        protected bool isSpawning = false;
        [SerializeField] protected List<GameObject> _fearInstances;

        protected virtual void Start()
        {
            _spawnPositionTransform = transform;
            _enemySettings = _enemySettings.Where(x => x != null).ToList();
            _spawnCount = _enemySettings.Count;
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

        public bool IsDone {
            get
            {
                return ((!_fearInstances.Any(x => x != null && x.activeInHierarchy))
                    && (_currentSpawnCount == _spawnCount));
            }
        }

        protected virtual void SpawnEnemy(int i)
        {
            var enemy = _enemySettings[i].Prefab;
            var path = _enemySettings[i].Path;
            var instance = Instantiate<GameObject>(enemy);
            var fearScript = instance.GetComponent<Fear>();
            fearScript.Walker.spline = path;
            _fearInstances.Add(instance);
            instance.SetActive(true);
            _currentSpawnCount++;
        }


        public virtual void CleanAllEnemies()
        {
            foreach (var enemySet in _fearInstances)
            {
                Destroy(enemySet);
            }
        }

        public virtual void StartSpawn()
        {
            isSpawning = true;
            Spawn();
        }


    }

    [Serializable]
    public class EnemySettings
    {
        [SerializeField] GameObject prefab;
        [SerializeField] BezierSpline path;

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
    }
}
