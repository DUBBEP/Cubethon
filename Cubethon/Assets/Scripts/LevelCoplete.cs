using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCoplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
