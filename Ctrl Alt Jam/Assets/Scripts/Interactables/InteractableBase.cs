using UnityEngine;

public class InteractableBase : MonoBehaviour, Interactable
{
    [SerializeField] private string _songName;
    [SerializeField] private string _tagToCompare;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_tagToCompare))
            Interact();
    }

    public virtual void Interact()
    {
        
    }

    public virtual void EndInteraction()
    {
        //play song with music manager
    }
}
 