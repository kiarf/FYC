using Assets.Script;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class GameOverManager : MonoBehaviour
    {
        public static GameOverManager instance;
        public GameObject gameOverUI;

        public void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Numerous GameOverManager instances in the scene");
                return;
            }

            instance = this;
        }

        public void OnPlayerDeath()
        {
            gameOverUI.SetActive(true);
        }

        public void RetryButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOverUI.SetActive(false);
        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}