using JAM.Projectils;
using UnityEngine;

namespace JAM.Pools
{
    public enum PoolType
    {
        FireBallProjectil,
        MobProjectil,
        TwisterProjectil
    }

    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private Pool _fireBallPool;
        [SerializeField] private Pool _mobProjectilPool;
        [SerializeField] private Pool _twisterProjectilPool;

        [SerializeField] private Transform _projectilPoolLocation;
        [SerializeField] private Transform _mobPoolLocation;
        [SerializeField] private Transform _twisterPoolLocation;

        public void Start()
        {
            InitPools();
        }

        public void InitPools()
        {
            _fireBallPool.Init(_projectilPoolLocation);
            //_bossProjectilPool.Init();
        }

        //public GameObject SelectPool()
        //{
            
        //}
    }
}