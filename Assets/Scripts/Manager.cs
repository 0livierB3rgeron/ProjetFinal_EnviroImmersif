using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField, Tooltip("ScoreDisplay GameObject")]
    private ScoreDisplay scoreDisplay;

    [SerializeField, Tooltip("Game over UI GameObjet")]
    private GameObject gameOverUI;
    
    void Update()
    {
        if (scoreDisplay.partieFinie)
        {
            // Display the game over UI.
            gameOverUI.SetActive(true);
        }
    }
}