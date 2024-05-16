
using UnityEngine;

namespace JAM.Projectils
{
    public interface IProjectil
    {
        public void InitializeProjectil(Vector3 position, Vector2 direction, Quaternion rotation);
    }
}
