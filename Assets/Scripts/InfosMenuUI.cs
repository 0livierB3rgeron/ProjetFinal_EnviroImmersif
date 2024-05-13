using UnityEngine;
using UnityEngine.UI;

public class InfosMenuUI : MonoBehaviour
{
    [SerializeField, Tooltip("Le GameObject du Tab sélectionné par défaut.")]
    private Tab defaultSelectedTab;

    /// <summary>
    /// Variable pour stocker le Tab sélectionné précédemment afin de pouvoir
    /// le déselectionner lorsqu'un nouveau Tab est sélectionné.
    /// </summary>
    private Tab previousSelectedTab;

    private void Start()
    {
        // Définir le Tab sélectionné par défaut dans la variable previousSelectedTab
        // au début de la scène.
        previousSelectedTab = defaultSelectedTab;
    }

    /// <summary>
    /// Fonction appelée par le Tab dans l'éditeur Unity lorsqu'on clique dessus.
    /// L'onglet sur lequel on a cliqué est passé en paramètre dans l'éditeur.
    /// </summary>
    /// <param name="tabSelected">l'onglet qui a été cliqué et qui a déclenché cet événement</param>
    public void OnTabChanged(Tab tabSelected)
    {
        // Désactiver le Tab précédent.
        previousSelectedTab.GetComponent<Toggle>().isOn = false;

        // Désactiver la Page du Tab précédent.
        previousSelectedTab.pageToShow.SetActive(false);

        // Activer la Page du nouveau Tab sélectionné.
        tabSelected.pageToShow.SetActive(true);

        // Changer la variable previousSelectedTab pour le Tab actuellement sélectionné.
        previousSelectedTab = tabSelected;
    }
}