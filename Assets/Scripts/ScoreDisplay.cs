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
    /// 
    /// </summary>
    public bool partieFinie;

    /// <summary>
    /// 
    /// </summary>
    private float _score = 0;

    private void Start()
    {
        partieFinie = false;
        foreach (var target in targets)
        {
            // Listen to OnPointsGained event.
            target.OnPointsGained += HandleOnPointsGained;
        }

        // Update the score UI text.
        scoreUIText.text = "Score: 0";
    }

    private void OnDisable()
    {
        foreach (var target in targets)
        {
            // Unsubscribe from the OnPointsGained event.
            target.OnPointsGained -= HandleOnPointsGained;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="points"></param>
    private void HandleOnPointsGained(float points)
    {
        _score += points;
        Debug.Log("Score: " + _score);
        scoreUIText.text = "Score: " + _score.ToString();
        if (_score == 120)
        {
            partieFinie=true;
        }
    }

}