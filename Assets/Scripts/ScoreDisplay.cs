using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField, Tooltip("Text child GameObject of the ScoreDisplay")]
    private Text scoreUIText;

    [SerializeField, Tooltip("All the target GameObjects")]
    private List<Target> targets;

    /// <summary>
    /// Boolean that keeps track of if the game is over.
    /// </summary>
    public bool partieFinie = false;

    /// <summary>
    /// Variable that stores the score.
    /// </summary>
    private float _score = 0;

    private void Start()
    {
        // Make sure that at the start of the game, the game is not over.
        partieFinie = false;
        foreach (var target in targets)
        {
            // Listen to each OnPointsGained event.
            target.OnPointsGained += HandleOnPointsGained;
        }

        // Apply the default score UI to the text.
        scoreUIText.text = "Score: 0";
    }

    private void OnDisable()
    {
        foreach (var target in targets)
        {
            // Unsubscribe from each of the OnPointsGained events.
            target.OnPointsGained -= HandleOnPointsGained;
        }
    }

    /// <summary>
    /// Function that is called when the OnPointsGained event is triggered.
    /// </summary>
    /// <param name="points">nombre de points à ajouter au score</param>
    private void HandleOnPointsGained(float points)
    {
        // Add the points to the score.
        _score += points;
        Debug.Log("Score: " + _score);
        // Update the score UI text.
        scoreUIText.text = "Score: " + _score.ToString();
        // Check if the game is over.
        if (_score == 120)
        {
            partieFinie = true;
        }
    }
}