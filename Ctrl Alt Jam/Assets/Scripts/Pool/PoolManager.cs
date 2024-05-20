using UnityEngine;

namespace JAM.Pools
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private PoolBase _projectilPool;
        [SerializeField] private PoolBase _mobPool;
        [SerializeField] private PoolBase _bossProjectilPool;

        public void Start()
        {
            InitPools();
            DontDestroyOnLoad(this);
        }

        public void InitPools()
        {
            _projectilPool.Init();
            _bossProjectilPool.Init();
        }
    }
}