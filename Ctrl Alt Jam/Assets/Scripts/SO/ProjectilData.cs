using UnityEngine;

namespace JAM.Projectils
{
    [CreateAssetMenu(menuName = "Data/Projectils")]
    public class ProjectilData : ScriptableObject
    {
        public Sprite sprite;
        public ParticleSystem projectilParticle;

        public int damage;
        public float damagePercent;
        public string tagToDamage;
        public float lifeTime;
        public float speed;
    }
}

