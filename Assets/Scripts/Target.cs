using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float _nbrPoints;

    [SerializeField]
    private ScoreDisplay scoreDisplay;
    
    private Animator _targetAnimator;
    private Collider _collider;

    /// <summary>
    /// Event that is invoked when points are gained.
    /// </summary>
    public event Action<float> OnPointsGained;

    private void Start()
    {
        this._targetAnimator = GetComponent<Animator>();
        this._collider = GetComponent<Collider>();

    }
    void Rotate()
    {
        this._targetAnimator.SetBool("isHidden", true);
    }
    public void OnHit()
    {
        OnPointsGained?.Invoke(this._nbrPoints);
        this._collider.enabled = false;
        Rotate();
    }
}