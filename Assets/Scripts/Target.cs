using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField, Tooltip("Nombre de points gagnés en touchant cette cible")]
    private float _nbrPoints;

    [SerializeField, Tooltip("ScoreDisplay GameObject")]
    private ScoreDisplay scoreDisplay;
    
    /// <summary>
    /// Reference to the animator component.
    /// </summary>
    private Animator _targetAnimator;
    /// <summary>
    /// Reference to the collider component.
    /// </summary>
    private Collider _collider;

    /// <summary>
    /// Event that is invoked when points are gained.
    /// It is listened to by the ScoreDisplay.
    /// </summary>
    public event Action<float> OnPointsGained;

    private void Start()
    {
        this._targetAnimator = GetComponent<Animator>();
        this._collider = GetComponent<Collider>();
    }

    /// <summary>
    /// Function to play the animation to hide the target.
    /// </summary>
    void Rotate()
    {
        // Tell the animator to play the animation to hide the target.
        this._targetAnimator.SetBool("isHidden", true);
    }

    /// <summary>
    /// Function triggered by the Ray Interactor when it hits the target.
    /// </summary>
    public void OnHit()
    {
        // Invoke the OnPointsGained event to notify the ScoreDisplay that points have been gained.
        OnPointsGained?.Invoke(this._nbrPoints);
        // Prevent the target from being hit again.
        this._collider.enabled = false;
        // Run the function that plays the animation to hide the target.
        Rotate();
    }
}