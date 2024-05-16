using System.Collections.Generic;
using UnityEngine;

namespace JAM.Pools
{
    public class PoolBase : MonoBehaviour
    {
        [SerializeField] private GameObject _poolObject;
        [SerializeField] private Queue<GameObject> _poolQueue;
        [SerializeField] private Transform _poolLocation;
        [SerializeField] private int _poolSize;

        private GameObject _obj;
        private GameObject _objSpawned;

        public virtual void Init()
        {
            _poolQueue = new Queue<GameObject>();

            for (int i = 0; i < _poolSize; i++)
            {
                _obj = SpawnPoolObject();

                if (_obj == null) continue;
              
                _obj.SetActive(false);
                _poolQueue.Enqueue(_obj);
                
            }
        }

        protected virtual GameObject SpawnPoolObject()
        {
            if (_objSpawned != null)
                _objSpawned = null;

            _objSpawned = Instantiate(_poolObject, _poolLocation);
            _objSpawned.transform.rotation = Quaternion.identity;

            if (_objSpawned == null) return null;
            
            IPoolable poolable = _objSpawned.GetComponent<IPoolable>();
            if (poolable == null) return null;
            
            poolable.Init();
            return ((MonoBehaviour)poolable).gameObject;

        }

        public GameObject GetObject()
        {
            if(_poolQueue.Count > 0)
            {
                GameObject obj = _poolQueue.Dequeue();        
                if(obj != null) return obj;
            }
            else
            {
                GameObject obj = Instantiate(_poolObject, _poolLocation);
                if (obj != null) return obj;
            }

            return null;
        }

        public void ReturnPoolObject(GameObject obj)
        {
            obj.SetActive(false);
            _poolQueue.Enqueue(obj);           
        }
    }
}