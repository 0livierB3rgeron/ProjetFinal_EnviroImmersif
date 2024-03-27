using System;
using UnityEngine;

public class ControllerData : MonoBehaviour
{
    /// <summary>
    /// Enum to define if this is the Left or Right Hand/Controller.
    /// </summary>
    public enum HandType
    {
        Left,
        Right
    }

    [SerializeField, Tooltip("Is this the Left or Right Hand controller?")]
    private HandType _handType;

    /// <summary>
    /// Event that is triggered when the user gets an item in one of his hands
    /// or drops an item from one of his hands.
    /// </summary>
    /// <param type="HandType">Enum to know if it is the Right Controller or the Left Controller that is sending the event.</param>
    /// <param type="bool">Is there an item in the specified hand (true or false)?</param>
    public event Action<HandType, bool> OnHasItemInHandChanged;

    /// <summary>
    /// This function is referenced in the Unity Editor in the Ray Interactor events and Direct Interactor events.
    /// When the ray interactor/direct interactor grabs or drops an item, this function is called.
    /// </summary>
    /// <param name="newValue">Is there an item in this hand (true or false)?</param>
    public void InvokeOnHasItemInHandChanged(bool newValue)
    {
        //Debug.Log("Invoke: " + this.name);
        // Raise the event to notify the Animator of the associated prefab that an item has been grabbed or dropped.
        // Pass the enum that tell which controller is sending the event (this one) and
        // the new value of if there is an item in this hand (true or false).
        OnHasItemInHandChanged?.Invoke(this._handType, newValue);
    }
}