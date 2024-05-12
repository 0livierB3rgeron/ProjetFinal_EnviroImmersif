using UnityEngine;
using UnityEngine.UI;

public class InfosMenuUI : MonoBehaviour
{
    [SerializeField, Tooltip("The default selected Tab GameObject.")]
    private Tab defaultSelectedTab;

    /// <summary>
    /// Variable to store the previous selected Tab
    /// to be able to un-toggle it when a new Tab is selected.
    /// </summary>
    private Tab previousSelectedTab;

    private void Start()
    {
        // Set the previousSelectedTab to the default selected tab
        // at the beginning of the scene.
        previousSelectedTab = defaultSelectedTab;
    }

    /// <summary>
    /// Function called by the Tab in the Unity editor when it is clicked.
    /// The tab that has been clicked is passed as a parameter in the editor.
    /// </summary>
    /// <param name="tabSelected">the tab that has been clicked and triggered this event</param>
    public void OnTabChanged(Tab tabSelected)
    {
        // Un-toggle the previous tab.
        previousSelectedTab.GetComponent<Toggle>().isOn = false;

        // Disable the previous tab's page.
        previousSelectedTab.pageToShow.SetActive(false);

        // Enable the new tab's page.
        tabSelected.pageToShow.SetActive(true);

        // Set the previousSelectedTab to the current tab.
        previousSelectedTab = tabSelected;
    }
}