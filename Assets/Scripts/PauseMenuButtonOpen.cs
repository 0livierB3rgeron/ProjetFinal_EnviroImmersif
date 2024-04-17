using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseMenuButtonOpen : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the InputAction: \"XRI LeftHand Interaction/Menu\" or \"XRI RightHand Interaction/Menu\"")]
    private InputActionReference menuButtonInputActionReference;

    [SerializeField, Tooltip("Reference to the GameParent object.")]
    private GameObject gameParent;

    [SerializeField, Tooltip("")]
    private XRRayInteractor leftControllerRayInteractor;
    [SerializeField, Tooltip("")]
    private XRRayInteractor rightControllerRayInteractor;
    [SerializeField, Tooltip("")]
    private XRDirectInteractor leftControllerDirectInteractor;
    [SerializeField, Tooltip("")]
    private XRDirectInteractor rightControllerDirectInteractor;

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
        if(Time.timeScale != 0f)
        {
            // Pause the game.
            Time.timeScale = 0f;

            // Retreive any GameObject that is currently being held in a hand.
            if (leftControllerRayInteractor.interactablesSelected.Count > 0)
            {
                // Add to List of GameObjects to be re-enabled when the game is unpaused.
                //itemsToReEnable.Add(leftControllerRayInteractor.interactablesSelected[0].transform.gameObject);
                // Disable the GameObject.
                leftControllerRayInteractor.interactablesSelected[0].transform.gameObject.SetActive(false);
            }
            if (rightControllerRayInteractor.interactablesSelected.Count > 0)
            {
                // Add to List of GameObjects to be re-enabled when the game is unpaused.
                //itemsToReEnable.Add(rightControllerRayInteractor.interactablesSelected[0].transform.gameObject);
                // Disable the GameObject.
                rightControllerRayInteractor.interactablesSelected[0].transform.gameObject.SetActive(false);
            }
            if (leftControllerDirectInteractor.interactablesSelected.Count > 0)
            {
                // Add to List of GameObjects to be re-enabled when the game is unpaused.
                //itemsToReEnable.Add(leftControllerDirectInteractor.interactablesSelected[0].transform.gameObject);
                // Disable the GameObject.
                leftControllerDirectInteractor.interactablesSelected[0].transform.gameObject.SetActive(false);
            }
            if (rightControllerDirectInteractor.interactablesSelected.Count > 0)
            {
                // Add to List of GameObjects to be re-enabled when the game is unpaused.
                //itemsToReEnable.Add(rightControllerDirectInteractor.interactablesSelected[0].transform.gameObject);
                // Disable the GameObject.
                rightControllerDirectInteractor.interactablesSelected[0].transform.gameObject.SetActive(false);
            }

            // Disable the GameParent to prevent rendering 2 scenes combined.
            gameParent.SetActive(false);

            // Open the PauseMenuScene as an overlay to keep the current state of the game.
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}