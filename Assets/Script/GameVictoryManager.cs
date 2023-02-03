using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    public class GameVictoryManager : MonoBehaviour
    {
        public static GameVictoryManager instance;
        public GameObject gameVictoryUi;

        public void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Numerous GameVictoryManager instances in the scene");
                return;
            }

            instance = this;
        }

        public void OnPlayerVictory()
        {
            gameVictoryUi.SetActive(true);
        }

        public void RetryButton()
        {
            gameVictoryUi.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}