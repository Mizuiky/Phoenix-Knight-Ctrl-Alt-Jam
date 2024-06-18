using System.Collections.Generic;
using UnityEngine;

namespace JAM.Pools
{
    [CreateAssetMenu(menuName = "Pools")]
    public class Pool : ScriptableObject
    {
        public GameObject _poolObject;
        public int _poolSize;

        private Transform _poolLocation;
        private Queue<GameObject> _poolQueue;

        private GameObject _obj;
        private GameObject _objSpawned;

        public virtual void Init(Transform poolLocation)
        {
            _poolQueue = new Queue<GameObject>();
            _poolLocation = poolLocation;

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