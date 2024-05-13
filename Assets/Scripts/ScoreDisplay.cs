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
            // Écoutez chaque événement OnPointsGained.
            target.OnPointsGained += HandleOnPointsGained;
        }

        // Appliquez le nombre de points par défaut dans le composant Text.
        scoreUIText.text = "Score: 0";
    }

    private void OnDisable()
    {
        // Boucler pour toutes les cibles.
        foreach (var target in targets)
        {
            // Se désabonner de tous les événements OnPointsGained.
            target.OnPointsGained -= HandleOnPointsGained;
        }
    }

    /// <summary>
    /// Fonction appelée lorsque l'événement OnPointsGained est invoqué.
    /// Met à jour le score et le texte du score et affiche le GameOverUI si le jeu est terminé.
    /// </summary>
    /// <param name="points">nombre de points à ajouter au score</param>
    private void HandleOnPointsGained(float points)
    {
        // Ajoutez les points au score.
        _score += points;
        // Mettre à jour le texte du UI du score.
        scoreUIText.text = "Score: " + _score.ToString();
        // Vérifier si le jeu est terminé.
        if (_score == 120)
        {
            // Afficher le UI de fin de partie.
            gameOverUI.SetActive(true);
        }
    }
}