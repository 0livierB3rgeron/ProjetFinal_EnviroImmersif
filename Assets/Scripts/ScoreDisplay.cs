using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField, Tooltip("GameObject enfant Text du ScoreDisplay")]
    private Text scoreUIText;

    [SerializeField, Tooltip("Tous les GameObjects Target")]
    private List<Target> targets;

    [SerializeField, Tooltip("GameObject GameOverUI")]
    private GameObject gameOverUI;

    /// <summary>
    /// Variable qui stocke le score.
    /// </summary>
    private float _score = 0;

    private void Start()
    {
        // Boucler pour toutes les cibles.
        foreach (var target in targets)
        {
            // �coutez chaque �v�nement OnPointsGained.
            target.OnPointsGained += HandleOnPointsGained;
        }

        // Appliquez le nombre de points par d�faut dans le composant Text.
        scoreUIText.text = "Score: 0";
    }

    private void OnDisable()
    {
        // Boucler pour toutes les cibles.
        foreach (var target in targets)
        {
            // Se d�sabonner de tous les �v�nements OnPointsGained.
            target.OnPointsGained -= HandleOnPointsGained;
        }
    }

    /// <summary>
    /// Fonction appel�e lorsque l'�v�nement OnPointsGained est invoqu�.
    /// Met � jour le score et le texte du score et affiche le GameOverUI si le jeu est termin�.
    /// </summary>
    /// <param name="points">nombre de points � ajouter au score</param>
    private void HandleOnPointsGained(float points)
    {
        // Ajoutez les points au score.
        _score += points;
        // Mettre � jour le texte du UI du score.
        scoreUIText.text = "Score: " + _score.ToString();
        // V�rifier si le jeu est termin�.
        if (_score == 120)
        {
            // Afficher le UI de fin de partie.
            gameOverUI.SetActive(true);
        }
    }
}