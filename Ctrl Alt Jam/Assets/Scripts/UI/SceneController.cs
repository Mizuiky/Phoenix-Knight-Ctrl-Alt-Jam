using UnityEngine;
using UnityEngine.SceneManagement;

namespace JAM.Scene
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void LoadSceneAsyncronous(string name)
        {
            SceneManager.LoadSceneAsync(name);
        }
    }
}