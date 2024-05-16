using UnityEngine;
using JAM.Characters;
using System.Collections;

namespace JAM.Projectils
{
    public class ProjectilLauncherBase : MonoBehaviour
    {
        [SerializeField] private Transform _firePosition;
        [SerializeField] private float _timeBetweenProjecteis;

        private CharacterBase _character;
        private GameObject _obj;

        private Vector3 _direction;
        private Coroutine _coroutine;

        public virtual void Init(CharacterBase character)
        {
            _character = character;
            _direction = Vector3.zero;
        }

        public void StartToLaunch()
        {
            if (_coroutine != null) return;
            StartCoroutine(LaunchCoroutine());
        }

        private IEnumerator LaunchCoroutine()
        {
            LaunchProjectil();
            yield return new WaitForSeconds(_timeBetweenProjecteis);
        }

        protected virtual void LaunchProjectil()
        {
            _direction = _character.characterComponents.movement.MovementDirection;
            _obj = CtrlAltJamGameManager.Instance.ProjectilPool.GetObject();

            IProjectil projectil = _obj.GetComponent<IProjectil>();
            if (projectil == null) return;

            projectil.InitializeProjectil(_firePosition.position, _direction, _character.transform.rotation);
        }
    }
}
