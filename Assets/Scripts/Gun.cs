using UnityEngine;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// Callback function triggered when the user presses the Trigger button
    /// while holding this gun.
    /// </summary>
    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}