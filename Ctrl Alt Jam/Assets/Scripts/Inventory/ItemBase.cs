using System;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IItem
{
    [SerializeField] protected ItemData data;

    public Action<ItemData> onCollect;
    public ParticleSystem collectParticle;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            OnCollect();
    }

    public virtual void OnCollect()
    {
        PlayParticle();
        onCollect?.Invoke(data);
    }

    public void PlayParticle()
    {

    }
}
