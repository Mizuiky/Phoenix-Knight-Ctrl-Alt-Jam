using JAM.Characters;
using UnityEngine;

namespace JAM.Projectils
{
    public class ProjectilLauncher : ProjectilLauncherBase
    {
        protected CharacterBase _character;

        public override void Init(CharacterBase character)
        {
            _character = character;
            _direction = Vector3.zero;
        }

        public override void LaunchProjectil()
        {
            _direction = _character.characterComponents.movement.MovementDirection;

            projectil = GetProjectil();

            if (projectil != null)
                projectil.InitializeProjectil(_firePosition.position, _direction, _character.transform.rotation);
        }
    }
}