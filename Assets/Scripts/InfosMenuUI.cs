using UnityEngine;
using UnityEngine.UI;

public class InfosMenuUI : MonoBehaviour
{
    [SerializeField, Tooltip("Le GameObject du Tab s�lectionn� par d�faut.")]
    private Tab defaultSelectedTab;

    /// <summary>
    /// Variable pour stocker le Tab s�lectionn� pr�c�demment afin de pouvoir
    /// le d�selectionner lorsqu'un nouveau Tab est s�lectionn�.
    /// </summary>
    private Tab previousSelectedTab;

    private void Start()
    {
        // D�finir le Tab s�lectionn� par d�faut dans la variable previousSelectedTab
        // au d�but de la sc�ne.
        previousSelectedTab = defaultSelectedTab;
    }

    /// <summary>
    /// Fonction appel�e par le Tab dans l'�diteur Unity lorsqu'on clique dessus.
    /// L'onglet sur lequel on a cliqu� est pass� en param�tre dans l'�diteur.
    /// </summary>
    /// <param name="tabSelected">l'onglet qui a �t� cliqu� et qui a d�clench� cet �v�nement</param>
    public void OnTabChanged(Tab tabSelected)
    {
        // D�sactiver le Tab pr�c�dent.
        previousSelectedTab.GetComponent<Toggle>().isOn = false;

        // D�sactiver la Page du Tab pr�c�dent.
        previousSelectedTab.pageToShow.SetActive(false);

        // Activer la Page du nouveau Tab s�lectionn�.
        tabSelected.pageToShow.SetActive(true);

        // Changer la variable previousSelectedTab pour le Tab actuellement s�lectionn�.
        previousSelectedTab = tabSelected;
    }
}