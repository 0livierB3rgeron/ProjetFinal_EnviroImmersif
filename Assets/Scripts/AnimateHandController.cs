using UnityEngine;
using UnityEngine.InputSystem;
using static ControllerData;

[RequireComponent(typeof(Animator))]
public class AnimateHandController : MonoBehaviour
{
    [SerializeField, Tooltip("\"XRI LeftHand Interaction/Select value\" or \"XRI RightHand Interaction/Select value\"")]
    private InputActionReference gripInputActionReference;

    [SerializeField, Tooltip("\"XRI LeftHand Interaction/Activate value\" or \"XRI RightHand Interaction/Activate value\"")]
    private InputActionReference triggerInputActionReference;

    [SerializeField, Tooltip("Is this the Left or Right Hand prefab?")]
    private HandType _handType;

    /// <summary>
    /// Animator Component of this hand prefab.
    /// </summary>
    private Animator _handAnimator;
    /// <summary>
    /// Current value of the Grip button on the controller (Between 0 and 1).
    /// </summary>
    private float _gripValue;
    /// <summary>
    /// Current value of the Trigger button on the controller (Between 0 and 1).
    /// </summary>
    private float _triggerValue;
    /// <summary>
    /// Current value of the boolean that tells if there is an item in the hand.
    /// </summary>
    private bool _hasItemInHand;

    private void Start()
    {
        // Get the Animator Component of this hand prefab.
        _handAnimator = GetComponent<Animator>();
        // Listen to Left Hand/Right Hand event.
        transform.parent.GetComponent<ControllerData>().OnHasItemInHandChanged += HandleHasItemInHandChanged;
    }

    private void OnDisable()
    {
        // Unsubscribe from Left Hand/Right Hand event.
        transform.parent.GetComponent<ControllerData>().OnHasItemInHandChanged -= HandleHasItemInHandChanged;
    }

    private void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    /// <summary>
    /// Every frame, update the animation of the hand prefab (the grip animation).
    /// </summary>
    private void AnimateGrip()
    {
        // Get the current value of the Grip button on the controller.
        _gripValue = gripInputActionReference.action.ReadValue<float>();
        // If there is an item in this hand
        if (this._hasItemInHand)
        {
            //Debug.Log("Ca grip fort");
            // Force the hand to be closed because there is an item in the hand
            // (even if the user is not pressing the Grip button).
            _handAnimator.SetFloat("Grip", 1f);
        }
        else
        {
            // Otherwise, set the hand animation according to the value of the Grip button.
            _handAnimator.SetFloat("Grip", _gripValue);
        }
    }

    /// <summary>
    /// Every frame, update the animation of the hand prefab (the pinch animation).
    /// </summary>
    private void AnimateTrigger()
    {
        // Get the current value of the Trigger button on the controller.
        _triggerValue = triggerInputActionReference.action.ReadValue<float>();
        // Set the hand animation according to the value of the Trigger button.
        _handAnimator.SetFloat("Trigger", _triggerValue);
    }

    /// <summary>
    /// Callback when the event "OnHasItemInHandChanged" is raised from either of the two hands.
    /// Its purpose is to store the new value of the boolean `_hasItemInHand` when the value changes
    /// so the animator is aware of the current state of the controller.
    /// </summary>
    /// <param name="handType">Enum to know if it is the Right Hand or the Left Hand that has sent the event.</param>
    /// <param name="newValue">Is there an item in the specified hand (true or false)?</param>
    private void HandleHasItemInHandChanged(HandType handType, bool newValue)
    {
        // If the hand that sent the event is the same as this hand prefab
        if (handType == this._handType)
        {
            //Debug.Log("Entendu!");
            this._hasItemInHand = newValue;
        }
        // Otherwise, (if it is an event for the other hand,) ignore the event.
    }
}