using JAM.Interactables;
using UnityEngine;

public class OrbeBase : MonoBehaviour, IOrbeBase
{
    [SerializeField] private ParticleSystem _orbeParticle;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _moveSpeed;

    private Transform _orbePosition;
    public bool _canShow = false;
    private float _elapsedTime;
    private Vector3 _targetPosition;

    public void Init(Transform position)
    {
        transform.localPosition = position.position;
        _canShow = false;
        _elapsedTime = 0;
        gameObject.SetActive(false);
        _targetPosition = transform.position + Vector3.up * 1.2f;
        transform.localScale = Vector3.one;
    }

    public void Reset()
    {
        _canShow = false;
        _elapsedTime = 0;
    }

    public void Update()
    {
        if(_canShow)
        {
            _elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _elapsedTime / _moveDuration * _moveSpeed  * Time.deltaTime);
            transform.localScale = Vector3.one;

            if (_elapsedTime > _moveDuration)
            {
                _canShow = false;
                transform.position = _targetPosition;
            }          
        }
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        _canShow = true;
    }
}
