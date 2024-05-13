using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameButton : MonoBehaviour
{
    /// <summary>
    /// Fonction appel�e lorsque le bouton de r�initialisation du GameOverUI ou du InfosMenuUI est cliqu�.
    /// R�initialise la sc�ne du jeu.
    /// </summary>
    public void ResetGame()
    {
        // R�initialiser (recharger � partir de z�ro) la sc�ne actuelle (la sc�ne de jeu).
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}