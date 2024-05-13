using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField, Tooltip("Nombre de points gagnés en touchant cette cible")]
    private float _nbrPoints;

    [SerializeField, Tooltip("GameObject ScoreDisplay")]
    private ScoreDisplay scoreDisplay;

    /// <summary>
    /// Référence au composant Animator.
    /// </summary>
    private Animator _targetAnimator;
    /// <summary>
    /// Référence au composant Collider.
    /// </summary>
    private Collider _collider;

    /// <summary>
    /// Événement invoqué lorsque des points sont gagnés.
    /// Il est écouté par le ScoreDisplay.
    /// </summary>
    public event Action<float> OnPointsGained;

    private void Start()
    {
        this._targetAnimator = GetComponent<Animator>();
        this._collider = GetComponent<Collider>();
    }

    /// <summary>
    /// Fonction pour jouer l'animation pour masquer la cible.
    /// </summary>
    void Rotate()
    {
        // Indiquer à l'Animator de jouer l'animation pour cacher la cible.
        this._targetAnimator.SetBool("isHidden", true);
    }

    /// <summary>
    /// Fonction déclenchée par le Ray Interactor lorsqu'il atteint la cible.
    /// </summary>
    public void OnHit()
    {
        // Invoquez l'événement OnPointsGained pour informer le ScoreDisplay que des points ont été gagnés.
        OnPointsGained?.Invoke(this._nbrPoints);
        // Empêchez la cible d'être touchée à nouveau.
        this._collider.enabled = false;
        // Exécutez la fonction qui joue l'animation pour masquer la cible.
        Rotate();
    }
}