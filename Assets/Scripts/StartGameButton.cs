using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    /// <summary>
    /// Fonction appel�e lorsque l'on appuie sur le bouton "Commencer le jeu".
    /// Changer la sc�ne vers la MainScene (sc�ne du jeu).
    /// </summary>
    public void OnPressed()
    {
        // Changer la sc�ne vers la MainScene (sc�ne du jeu).
        SceneManager.LoadScene("MainScene"); // La sc�ne doit �tre ajout�e aux Build Settings.
    }
}