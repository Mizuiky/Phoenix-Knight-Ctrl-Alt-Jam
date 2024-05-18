using UnityEngine;

namespace JAM.Projectils
{
    public class TwisterLauncher : ProjectilLauncherBase
    {
        [SerializeField] private int _projectilQtd = 6;
        [SerializeField] private float _shootAngle = 45;
        private int mult = 0;

        public override void Init()
        {
            base.Init();
            mult = 0;
        }

        public override void LaunchProjectil()
        {
            Debug.Log("is launching projectil");

            _direction = _firePosition.position;

            for (int i = 0; i < _projectilQtd; i++)
            {
                if (mult % 2 == 0)
                    mult++;

                _obj = CtrlAltJamGameManager.Instance.BossProjectilPool.GetObject();

                IProjectil projectil = _obj.GetComponent<IProjectil>();
                if (projectil == null) return;

                float angle = (i % 2 == 0 ? _shootAngle : -_shootAngle) * mult;
                Debug.Log("angle");

                Quaternion quaternion = Quaternion.Euler(angle, 0, angle);

                projectil.InitializeProjectil(_firePosition.position, _direction, quaternion);
            }           
        }
    }
}
