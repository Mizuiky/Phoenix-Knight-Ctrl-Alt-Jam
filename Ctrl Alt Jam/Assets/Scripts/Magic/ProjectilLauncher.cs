using UnityEngine;
using JAM.Characters;

namespace JAM.Projectils
{
    public class ProjectilLauncher : MonoBehaviour
    {
        [SerializeField] private Transform _firePosition;
        [SerializeField] private float _timeBetweenProjecteis;

        private Player _player;
        private GameObject _obj;

        private Vector3 _direction;
        public Vector2 Direction { get { return _direction; } set {  _direction = value; } }

        public void Init(Player player)
        {
            _player = player;
            _direction = Vector3.zero;
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
            _obj = CtrlAltJamGameManager.Instance.ProjectilPool.GetObject();

            IProjectil projectil = _obj.GetComponent<IProjectil>();
            if (projectil == null) return;

            projectil.InitializeProjectil(_firePosition.position, _direction, _player.transform.rotation);
        }
    }
}
