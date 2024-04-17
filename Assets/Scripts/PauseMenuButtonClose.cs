using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuButtonClose : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the InputAction: \"XRI LeftHand Interaction/Menu\" or \"XRI RightHand Interaction/Menu\"")]
    private InputActionReference menuButtonInputActionReference;

    private void OnEnable()
    {
        // Subscribe to the event triggered when the menu button is pressed.
        menuButtonInputActionReference.action.performed += OnMenuButtonPressed;
    }

    private void OnDisable()
    {
        menuButtonInputActionReference.action.performed -= OnMenuButtonPressed;
    }

    private void OnMenuButtonPressed(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f)
        {
            // Re-Enable Camera
            // Un-pause the game.
            Time.timeScale = 1f;

            // Unload the PauseMenuScene.
            SceneManager.UnloadSceneAsync(1);
        }
    }
}