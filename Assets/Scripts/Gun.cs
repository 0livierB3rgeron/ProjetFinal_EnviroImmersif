using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Tooltip("Select the layers that contain targets")]
    private LayerMask validLayersMask;

    /// <summary>
    /// Function triggered by the gun when the player pressed the trigger button on the controller.
    /// Plays the shooting sound of the gun, tests if the gun shot a target and run the action of the shot target.
    /// </summary>
    public void Shoot()
    {
        // Play the shooting sound of the gun.
        GetComponent<AudioSource>().Play();

        // Test if the gun shot a target and run the action of the shot target.
        RaycastHit hit;
        // If the ray intersect a target, call the OnHit() method of this Target GameObject.
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, validLayersMask))
        {
            //Debug.Log(hit.transform.gameObject.name);
            hit.transform.gameObject.GetComponent<Target>().OnHit();
        }
    }
}