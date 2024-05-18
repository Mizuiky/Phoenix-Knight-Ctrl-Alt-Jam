using UnityEngine;
using JAM.Characters;

namespace JAM.Projectils
{
    public class ProjectilLauncherBase : MonoBehaviour
    {
        [SerializeField] protected Transform _firePosition;

        protected GameObject _obj;

        protected Vector3 _direction;
        protected IProjectil projectil;

        public virtual void Init() 
        {
            _direction = Vector3.zero;
        }
        public virtual void Init(CharacterBase character) {}

        public virtual void LaunchProjectil(){}

        public virtual void LaunchProjectil(Vector3 direction)
        {
            _direction = direction;
        }

        protected IProjectil GetProjectil()
        {
            _obj = CtrlAltJamGameManager.Instance.ProjectilPool.GetObject();

            IProjectil projectil = _obj.GetComponent<IProjectil>();
            if (projectil == null) return null;

            return projectil;
        }
    }
}
