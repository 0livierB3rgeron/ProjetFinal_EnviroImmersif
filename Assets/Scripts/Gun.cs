using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private LayerMask validLayersMask;

    public void Shoot()
    {
        RaycastHit hit;
        // If the ray intersect a target, call the OnHit() method of this Target GameObject.
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, validLayersMask))
        {
            //Debug.Log(hit.transform.gameObject.name);
            hit.transform.gameObject.GetComponent<Target>().OnHit();
        }
    }
}