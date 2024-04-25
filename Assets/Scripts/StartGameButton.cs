using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void OnPressed()
    {
        // Switch Scene to MainScene.
        SceneManager.LoadScene("MainScene"); // The Scene needs to be added to the Build Settings.
    }
}