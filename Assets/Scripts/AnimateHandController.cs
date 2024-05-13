using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimateHandController : MonoBehaviour
{
    [SerializeField, Tooltip("\"XRI LeftHand Interaction/Select value\" ou \"XRI RightHand Interaction/Select value\"")]
    private InputActionReference gripInputActionReference;

    [SerializeField, Tooltip("\"XRI LeftHand Interaction/Activate value\" ou \"XRI RightHand Interaction/Activate value\"")]
    private InputActionReference triggerInputActionReference;

    /// <summary>
    /// Composant Animator du prefab de cette main.
    /// </summary>
    private Animator _handAnimator;
    /// <summary>
    /// Valeur actuelle du bouton Grip sur le Controller (Entre 0 and 1).
    /// </summary>
    private float _gripValue;
    /// <summary>
    /// Valeur actuelle du bouton Trigger sur le Controller (Entre 0 and 1).
    /// </summary>
    private float _triggerValue;

    private void Start()
    {
        // R�cup�rer le composant Animator du prefab de cette main.
        _handAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    /// <summary>
    /// � chaque frame, met � jour l'animation du prefab de la main (l'animation de Grip).
    /// </summary>
    private void AnimateGrip()
    {
        // R�cup�rer la valeur actuelle du bouton Grip sur la manette.
        _gripValue = gripInputActionReference.action.ReadValue<float>();
        // D�finir l'animation de la main selon la valeur du bouton Grip.
        _handAnimator.SetFloat("Grip", _gripValue);
    }

    /// <summary>
    /// � chaque frame, met � jour l'animation du prefab de la main (l'animation de Pinch).
    /// </summary>
    private void AnimateTrigger()
    {
        // R�cup�rer la valeur actuelle du bouton Trigger sur la manette.
        _triggerValue = triggerInputActionReference.action.ReadValue<float>();
        // D�finir l'animation de la main selon la valeur du bouton Trigger.
        _handAnimator.SetFloat("Trigger", _triggerValue);
    }
}