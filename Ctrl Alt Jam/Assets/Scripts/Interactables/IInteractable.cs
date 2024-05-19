
namespace JAM.Interactables
{
    public interface IInteractable
    {
        public void Init();
        public void Reset();
        public void Interact();
        public void EndInteraction();
    }
}