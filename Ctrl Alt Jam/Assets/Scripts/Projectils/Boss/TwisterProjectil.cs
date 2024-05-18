using Unity.Mathematics;
using UnityEngine;

namespace JAM.Projectils
{
    public class TwisterProjectil : ProjectilBase
    {
        public override void InitializeProjectil(Vector3 position, Vector2 direction, Quaternion quaternion)
        {
            Debug.Log("Initilize twister");
            transform.localPosition = position;
            _direction = direction;
            transform.localRotation = quaternion;
            
            Activate();
        }
    }
}