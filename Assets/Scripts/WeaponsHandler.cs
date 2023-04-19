using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Handle weapons in the VR game, like damage and description
/// </summary>
public class WeaponsHandler : MonoBehaviour
{
    [SerializeField]
    float damage;
    [SerializeField]
    float range;
    [SerializeField]
    GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        WeaponHitDetection();
    }

    /// <summary>
    /// Detect if the weapon hit an enemy
    /// </summary>
    void WeaponHitDetection()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, range, transform.forward);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log("Hit");
            }
        }
    }

    /// <summary>
    /// Activate the canvas when the player hover of the weapon
    /// </summary>
    public void ActivateCanvas()
    {
        canvas.SetActive(true);
    }

    /// <summary>
    /// Desactivate the canvas when the player exit the hover of the weapon
    /// </summary>
    public void DesactivateCanvas()
    {
        canvas.SetActive(false);
    }
}
