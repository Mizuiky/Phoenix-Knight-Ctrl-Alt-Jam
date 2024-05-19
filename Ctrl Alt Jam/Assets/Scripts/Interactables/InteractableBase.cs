using UnityEngine;

namespace JAM.Interactables
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _songName;

        public void Start()
        {
            Init();
        }

        public virtual void Init()
        {

        }

        public virtual void Reset()
        {

        }

        public virtual void Interact()
        {

        }

        public virtual void EndInteraction()
        {
            //play song with music manager
        }
    }
}