using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Tooltip("Sélectionnez les layers qui contiennent des Target.")]
    private LayerMask validLayersMask;

    /// <summary>
    /// Fonction déclenchée par le pistolet lorsque le joueur appuie sur le bouton trigger de la manette.
    /// Joue le son de tir du pistolet, teste si le pistolet a tiré sur un Target et exécute l'action du Target touché.
    /// </summary>
    public void Shoot()
    {
        // Jouer le son de tir du pistolet.
        GetComponent<AudioSource>().Play();

        // Tester si le pistolet a tiré sur un Target et exécuter l'action du Target touché.
        RaycastHit hit;
        // Si le Raycast croise un Target, appeler la fonction OnHit() de ce GameObject Target.
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, validLayersMask))
        {
            hit.transform.gameObject.GetComponent<Target>().OnHit();
        }
    }
}