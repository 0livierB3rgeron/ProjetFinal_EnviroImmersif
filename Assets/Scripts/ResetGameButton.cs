using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameButton : MonoBehaviour
{
    /// <summary>
    /// Function called when the reset button on the game over UI or on the infos UI
    /// is clicked.
    /// Resets the scene of the game.
    /// </summary>
    public void ResetGame()
    {
        // Reset (Reload from scratch) the current scene (the game scene).
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}