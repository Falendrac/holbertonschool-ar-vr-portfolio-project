using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Vector3 lastPosition;
    private float speed;

    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Vector3.Distance(transform.position, lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }

    /// <summary>
    /// Detect if the weapon hit an enemy
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Enemy" && speed > 2)
        {
            other.gameObject.GetComponent<EnemyHandler>().TakeDamage(damage);
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
