using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameButton : MonoBehaviour
{
    public void ResetGame()
    {
        // Reset (Reload from scratch) the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}