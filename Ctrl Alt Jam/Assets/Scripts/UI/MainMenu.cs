using UnityEngine;
using UnityEngine.SceneManagement;

namespace JAM.Scene
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("agathaDream");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}