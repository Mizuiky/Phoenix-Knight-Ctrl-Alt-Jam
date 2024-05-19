using UnityEngine;

namespace JAM.Interactables
{
    public class InteractableChest : InteractableBase
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _orbeParent;
        [SerializeField] private GameObject _orbePrefab;

        private IOrbeBase _orbe;

        public override void Init()
        {
            GameObject obj = Instantiate(_orbePrefab, _orbeParent);
            obj.transform.localScale = Vector3.one;

            _orbe = obj.GetComponent<OrbeBase>();
            if (_orbe != null)
                _orbe.Init(_orbeParent);
        }

        public override void Reset()
        {
            _animator.SetBool("isOpen", false);
        }

        public override void Interact()
        {
            Debug.Log("open");
            _animator.SetBool("isOpen", true);
        }

        public override void EndInteraction()
        {
            _orbe.Show();
        }
    }
}
