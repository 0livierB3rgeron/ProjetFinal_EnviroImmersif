using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float _nbrPoints;

    [SerializeField]
    private ScoreDisplay scoreDisplay;
    
    private Animator _targetAnimator;

    /// <summary>
    /// 
    /// </summary>
    public event Action<float> OnPointsGained;

    private void Start()
    {
        this._targetAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Rotate()
    {
        //for (int i = 270; i != 0; i-=5)
        //{
        //    gameObject.transform.Rotate(new Vector3(i, transform.rotation.y, transform.rotation.z));
        //} 
        this._targetAnimator.SetBool("isHidden", true);
    }
    public void OnHit()
    {
        OnPointsGained?.Invoke(this._nbrPoints);
        Rotate();
    }
}