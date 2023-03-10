using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public void LevelComplete()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame() 
    {
        if (gameHasEnded == false) 
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            Debug.Log("SceneEnded");
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
