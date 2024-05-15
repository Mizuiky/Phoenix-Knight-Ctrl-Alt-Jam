using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InteractableTorch : InteractableBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Light2D _torchLight;
    [SerializeField] private Collider2D _collider;

    [SerializeField] private bool _hasLightUp;
    public bool HasLightUp { get { return _hasLightUp; } }
   
    public override void Init()
    {
        _torchLight.intensity = 0f;
        _hasLightUp = false;
    }

    public override void Interact()
    {
        if(!_hasLightUp)
            LightUp();
    }

    public void LightUp()
    {
        _animator.SetTrigger("TurnOn");
        _hasLightUp = true;
    }

    public override void EndInteraction()
    {
        base.EndInteraction();     
    }
}
