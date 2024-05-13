using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameButton : MonoBehaviour
{
    /// <summary>
    /// Fonction appelée lorsque le bouton de réinitialisation du GameOverUI ou du InfosMenuUI est cliqué.
    /// Réinitialise la scène du jeu.
    /// </summary>
    public void ResetGame()
    {
        // Réinitialiser (recharger à partir de zéro) la scène actuelle (la scène de jeu).
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}