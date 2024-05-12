using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    /// <summary>
    /// Function called when the "Commencer le jeu" button is pressed.
    /// Switches the Scene to the MainScene (scene with the game).
    /// </summary>
    public void OnPressed()
    {
        // Switch Scene to MainScene.
        SceneManager.LoadScene("MainScene"); // The Scene needs to be added to the Build Settings.
    }
}