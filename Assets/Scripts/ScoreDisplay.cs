using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private Text scoreUIText;

    [SerializeField]
    private List<Target> targets;

    /// <summary>
    /// 
    /// </summary>
    public event Action OnScoreReset;

    private float _score = 0;

    private void Start()
    {
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
    }
}