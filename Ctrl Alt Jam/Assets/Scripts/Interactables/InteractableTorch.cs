using System.Collections;
using UnityEngine;

public class InteractableTorch : InteractableBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Light _torchLight;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _timeToLightUp;
   
    public override void Interact()
    {
        StartCoroutine(LightUp());
    }

    public IEnumerator LightUp()
    {

        yield return new WaitForSeconds(_timeToLightUp);
        EndInteraction();
    }

    public override void EndInteraction()
    {
        base.EndInteraction();
    }

}
