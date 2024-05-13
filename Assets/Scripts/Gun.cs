using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Tooltip("S�lectionnez les layers qui contiennent des Target.")]
    private LayerMask validLayersMask;

    /// <summary>
    /// Fonction d�clench�e par le pistolet lorsque le joueur appuie sur le bouton trigger de la manette.
    /// Joue le son de tir du pistolet, teste si le pistolet a tir� sur un Target et ex�cute l'action du Target touch�.
    /// </summary>
    public void Shoot()
    {
        // Jouer le son de tir du pistolet.
        GetComponent<AudioSource>().Play();

        // Tester si le pistolet a tir� sur un Target et ex�cuter l'action du Target touch�.
        RaycastHit hit;
        // Si le Raycast croise un Target, appeler la fonction OnHit() de ce GameObject Target.
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, validLayersMask))
        {
            hit.transform.gameObject.GetComponent<Target>().OnHit();
        }
    }
}