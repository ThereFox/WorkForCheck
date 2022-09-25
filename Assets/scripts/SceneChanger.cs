using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItemsSorting
{
    public class SceneChanger : MonoBehaviour
    {
        private int currentSceneId = 0;
        private int sceneCount = 1;

        private void Start()
        {
            var neededLevel = PlayerPrefs.GetInt("LastScene", 0);
            currentSceneId = SceneManager.GetActiveScene().buildIndex;
            sceneCount = SceneManager.sceneCountInBuildSettings;
            if(neededLevel != currentSceneId)
            {
                LoadConcreteLevel(neededLevel);
            }
        }
        public void LoadConcreteLevel(int LevelIndex)
        {
            SceneManager.LoadSceneAsync(LevelIndex);
            PlayerPrefs.SetInt("LastScene", LevelIndex);
        }

        public void LoadNextLevel()
        {
            if (sceneCount - 1 == currentSceneId)
            {
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
                PlayerPrefs.SetInt("LastScene", 0);
            }
            else
            {
                SceneManager.LoadSceneAsync(currentSceneId + 1, LoadSceneMode.Additive);
                PlayerPrefs.SetInt("LastScene", currentSceneId + 1);
            }
        }
        public void ReLoadScene()
        {
            SceneManager.LoadScene(currentSceneId);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReLoadScene();
            }
        }
    }
}
