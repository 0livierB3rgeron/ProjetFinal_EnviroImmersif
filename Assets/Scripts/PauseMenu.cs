using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField, Tooltip("The default selected tab.")]
    private Tab defaultSelectedTab;

    private Tab previousSelectedTab;

    private void Start()
    {
        // Set the previousSelectedTab to the default selected tab.
        previousSelectedTab = defaultSelectedTab;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tabSelected"></param>
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