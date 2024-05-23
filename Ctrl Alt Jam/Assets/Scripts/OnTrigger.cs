using UnityEngine;
using JAM.Characters;
using UnityEngine.SceneManagement;
public class OnTrigger : MonoBehaviour
{
    public string name;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("Player"))
        {
            Player ply = collision.gameObject.GetComponent<Player>();
            if (ply != null)
                SceneManager.LoadScene(name);

        }
    }
}
