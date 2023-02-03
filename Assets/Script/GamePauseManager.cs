using UnityEngine;

namespace Assets.Script
{
    public class GamePauseManager : MonoBehaviour
    {
        public static bool isPaused;

        public GameObject pauseMenu;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
            }
        }

        public void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
}