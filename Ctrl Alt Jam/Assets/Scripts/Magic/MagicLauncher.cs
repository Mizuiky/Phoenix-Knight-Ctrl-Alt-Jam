using UnityEngine;
using JAM.Characters;

namespace JAM.Projectils
{
    public class MagicLauncher : MonoBehaviour
    {
        [SerializeField] private ProjectilBase _projectil;
        [SerializeField] private Transform _firePosition;
        [SerializeField] private float _timeBetweenProjecteis;

        private Player _player;

        public void Init(Player player)
        {
            _player = player;
        }

        void Start()
        {

        }

        void Update()
        {

        }

        private void LaunchProjectil()
        {

        }
    }
}
