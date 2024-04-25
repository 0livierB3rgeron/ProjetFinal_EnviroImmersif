using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private Text scoreUIText;

    /// <summary>
    /// 
    /// </summary>
    public event Action<float> OnPointsGained;

    /// <summary>
    /// 
    /// </summary>
    public event Action OnScoreReset;

    private float _score = 0;

    private void Start()
    {
        // Listen to OnPointsGained event.
        OnPointsGained += HandleOnPointsGained;

        // Update the score UI text.
        scoreUIText.text = "Score: 0";
    }

    private void OnDisable()
    {
        // Unsubscribe from the event.
        OnPointsGained -= HandleOnPointsGained;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="points"></param>
    private void HandleOnPointsGained(float points)
    {
        _score += points;
        scoreUIText.text = "Score: " + _score.ToString();
    }
}