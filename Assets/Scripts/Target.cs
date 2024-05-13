using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField, Tooltip("Nombre de points gagn�s en touchant cette cible")]
    private float _nbrPoints;

    [SerializeField, Tooltip("GameObject ScoreDisplay")]
    private ScoreDisplay scoreDisplay;

    /// <summary>
    /// R�f�rence au composant Animator.
    /// </summary>
    private Animator _targetAnimator;
    /// <summary>
    /// R�f�rence au composant Collider.
    /// </summary>
    private Collider _collider;

    /// <summary>
    /// �v�nement invoqu� lorsque des points sont gagn�s.
    /// Il est �cout� par le ScoreDisplay.
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
        // Indiquer � l'Animator de jouer l'animation pour cacher la cible.
        this._targetAnimator.SetBool("isHidden", true);
    }

    /// <summary>
    /// Fonction d�clench�e par le Ray Interactor lorsqu'il atteint la cible.
    /// </summary>
    public void OnHit()
    {
        // Invoquez l'�v�nement OnPointsGained pour informer le ScoreDisplay que des points ont �t� gagn�s.
        OnPointsGained?.Invoke(this._nbrPoints);
        // Emp�chez la cible d'�tre touch�e � nouveau.
        this._collider.enabled = false;
        // Ex�cutez la fonction qui joue l'animation pour masquer la cible.
        Rotate();
    }
}