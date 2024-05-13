using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    /// <summary>
    /// Fonction appelée lorsque l'on appuie sur le bouton "Commencer le jeu".
    /// Changer la scène vers la MainScene (scène du jeu).
    /// </summary>
    public void OnPressed()
    {
        // Changer la scène vers la MainScene (scène du jeu).
        SceneManager.LoadScene("MainScene"); // La scène doit être ajoutée aux Build Settings.
    }
}