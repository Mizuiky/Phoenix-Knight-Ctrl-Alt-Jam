using UnityEngine;
using JAM.Characters;

namespace JAM.Projectils
{
    public class MagicLauncher : MonoBehaviour
    {
        [SerializeField] private Transform _firePosition;
        [SerializeField] private float _timeBetweenProjecteis;

        private Player _player;
        private GameObject _obj;
        private Vector3 _direction = Vector3.zero;

        public void Init(Player player)
        {
            _player = player;
        }

        void Start()
        {

        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha3)) 
            {
                LaunchProjectil();
            }
        }

        private void LaunchProjectil()
        {
            Debug.Log("Projectil");
            _obj = CtrlAltJamGameManager.Instance.ProjectilPool.GetObject();

            IProjectil projectil = _obj.GetComponent<IProjectil>();
            if (projectil == null) return;

            projectil.InitializeProjectil(_firePosition.position, _player.transform);
        }
    }
}
