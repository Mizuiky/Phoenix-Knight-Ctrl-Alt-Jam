using UnityEngine;

public interface IDamageable
{
    public void Damage(float damage);
    public void Damage(Vector2 direction, float damage);
}
