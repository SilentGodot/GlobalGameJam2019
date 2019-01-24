using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Wave
{
    public class Wave : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> _enemyPrefabs;


        [SerializeField] protected int _spawnCount;
        protected int _currentSpawnCount;

        [SerializeField] List<int> _spawnDelays;

        
        [Space]
        [Header("Spawn Pos")]
        protected Transform _spawnPositionTransform;
        [SerializeField] protected Vector3 _distanceFromPos;


        protected bool isSpawning = false;

        protected virtual void Start()
        {
            _spawnPositionTransform = transform;

        }

        // Update is called once per frame
        protected virtual void Update()
        {
            _enemyPrefabs = _enemyPrefabs.Where(x => x != null).ToList();
            Spawn();
        }

    }
}
